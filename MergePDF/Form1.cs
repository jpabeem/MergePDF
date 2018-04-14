using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class Form1 : Form
    {
        private List<Label> Labels { get; set; }
        private List<Button> Buttons { get; set; }
        private List<TextBox> Textboxes { get; set; }
        private List<OpenFileDialog> FileDialogs { get; set; }

        private List<string> Documents { get; set; }

        // Create a document for the merged result.
        private PdfDocument outDocument { get; set; }

        private OpenFileDialog openFileDialog { get; set; }
        private SaveFileDialog saveFileDialog { get; set; }

        public Form1()
        {
            InitializeComponent();
            Labels = new List<Label>();
            Buttons = new List<Button>();
            Textboxes = new List<TextBox>();
            FileDialogs = new List<OpenFileDialog>();
            Documents = new List<string>();
            CreateOpenFileDialog();
            CreateSaveFileDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richConsole.AppendText("Initialized MergePDF, ready to merge!\n");
            btnMergePdf.Enabled = false;
        }

        private void richConsole_Enter(object sender, EventArgs e)
        {
            ActiveControl = null;
        }

        private void CopyPages(PdfDocument from, PdfDocument to)
        {
            for (int i = 0; i < from.PageCount; i++)
            {
                to.AddPage(from.Pages[i]);
            }
        }

        private void btnMergePdf_Click(object sender, EventArgs e)
        {

            outDocument = new PdfDocument();

            try
            {
                using (PdfDocument outPdf = new PdfDocument())
                {
                    foreach (var document in Documents)
                    {
                        document.Replace(@"\", "/");
                        PdfDocument importPdf = PdfReader.Open(document, PdfDocumentOpenMode.Import);
                        CopyPages(importPdf, outPdf);
                    }
                    var outputLocation = saveFileDialog.FileName.Replace(@"\", "/");
                    outPdf.Save(outputLocation);
                }

                richConsole.AppendText(string.Format("Merged successfully!\n"));
            }catch(Exception ex)
            {
                MessageBox.Show("Uh-oh, something went wrong. Are you sure you have specified valid input and output paths?", "Merging error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richConsole.AppendText(string.Format("Error: {0}\n", ex.Message));
            }
        }

        private void richConsole_TextChanged(object sender, EventArgs e)
        {
            richConsole.SelectionStart = richConsole.Text.Length;
            richConsole.ScrollToCaret();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richConsole.Clear();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                return;

            btnMergePdf.Enabled = true;
            ShowMergeRows(Int32.Parse(comboBox1.Items[comboBox1.SelectedIndex].ToString()));
        }

        private void RemoveMergeRows()
        {
            foreach(var button in Buttons)
            {
                Controls.Remove(button);
            }

            foreach(var label in Labels)
            {
                Controls.Remove(label);
            }

            foreach(var txtBox in Textboxes)
            {
                Controls.Remove(txtBox);
            }

            Buttons.Clear();
            Labels.Clear();
            Textboxes.Clear();
            Documents.Clear();
        }

        private void CreateOpenFileDialog()
        {
            openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Title = "Open PDF file";
            openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }

        private void CreateSaveFileDialog()
        {
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Title = "Save merged PDF file at";
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;
        }

        private TextBox CreateTextbox(int yOffset)
        {
            TextBox textBox = new TextBox();
            textBox.Location = new Point(126, yOffset + 1);
            textBox.Size = new Size(490, 20);
            textBox.Visible = true;
            textBox.ReadOnly = true;
            Textboxes.Add(textBox);

            return textBox;
        }

        private Button CreateSaveButton(int yOffset)
        {
            Button button = new Button();
            button.Location = new Point(10, yOffset);
            button.Text = string.Format("Save file at");
            button.Visible = true;

            button.Click += (sender, e) =>
            {
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    Textboxes.Last().Text = saveFileDialog.FileName;
                    richConsole.AppendText(string.Format("Output location set: {0}\n", saveFileDialog.FileName));
                }
            };

            Buttons.Add(button);

            return button;
        }

        private Button CreateOpenButton(int yOffset, int increment)
        {
            Button button = new Button();
            button.Location = new Point(10, yOffset);
            button.Text = string.Format("Browse file {0}", increment + 1);
            button.Visible = true;

            button.Click += (sender, e) =>
            {
                var dialog = openFileDialog;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = dialog.FileName;
                        Documents.Add(fileName);
                        Textboxes[increment].Text = fileName;
                    }
                    catch(System.IO.IOException)
                    {
                        MessageBox.Show("Uh-oh, something went wrong. Please try closing all the PDF files you want to import", "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        richConsole.AppendText("Something went wrong, please try closing all the PDF files you want to import first.\n");
                    }
                   
                }
            };

            Buttons.Add(button);

            return button;
        }

        private void ShowMergeRows(int totalRows)
        {
            RemoveMergeRows();
            int startY = 100;

            for (int i = 0; i < totalRows; i++)
            {
                var textBox = CreateTextbox(startY);
                Controls.Add(textBox);

                var button = CreateOpenButton(startY, i);
                Controls.Add(button);

                startY += 45;
            }

            var saveTextBox = CreateTextbox(startY);
            Controls.Add(saveTextBox);

            var saveButton = CreateSaveButton(startY);
            Controls.Add(saveButton);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            RemoveMergeRows();
            richConsole.Clear();
            comboBox1.SelectedIndex = -1;
            btnMergePdf.Enabled = false;
        }
    }
}
