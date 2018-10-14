using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Linq;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class Form1 : Form
    {
        // Create a document for the merged result.
        private PdfDocument outDocument { get; set; }

        private Button addMoreFiles;
        private SaveOutputSelectorControl saveControl;

        public Form1()
        {
            InitializeComponent();
            this.DragEnter += new DragEventHandler(DragEnter_Handler);
            this.DragDrop += new DragEventHandler(DragDrop_Handler);
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            richConsole.AppendText("Initialized MergePDF, ready to merge!\n");

            CreateInitialSelectors();
        }

        private void CreateInitialSelectors()
        {
            panel1.AutoScroll = true;
            panel1.FlowDirection = FlowDirection.TopDown;
            panel1.WrapContents = false;

            var selector = new PdfSelectorControl(1);
            panel1.Controls.Add(selector);

            var selector2 = new PdfSelectorControl(2);
            panel1.Controls.Add(selector2);
            

            saveControl = new SaveOutputSelectorControl((val) => richConsole.AppendText(val));
            panel1.Controls.Add(saveControl);

            addMoreFiles = new Button()
            {
                Margin = new Padding(12, 0, 0, 0),
                Width = 518,
                Text = "Add more files",
                Visible = true
            };

            addMoreFiles.Click += AddMoreFiles_Click;

            panel1.Controls.Add(addMoreFiles);
        }

        private void AddMoreFiles_Click(object sender, EventArgs e)
        {
            var selectorX = new PdfSelectorControl(panel1.Controls.Count - 1)
            {
                Width = panel1.Width - 50
            };

            panel1.Controls.Add(selectorX);

            //Adding again will make it stick to bottom
            panel1.Controls.Add(saveControl);
            panel1.Controls.Add(addMoreFiles);
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

            var savePath = saveControl.FileName;
            if (string.IsNullOrWhiteSpace(savePath))
            {
                MessageBox.Show("Please specify save path", "Merging error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var pdfs = panel1.Controls.Cast<object>()
             .Where(x => x is PdfSelectorControl)
             .Select(x => x as PdfSelectorControl)
             .OrderBy(x => x.Index)
             .Where(x => string.IsNullOrWhiteSpace(x.FileName) == false)
             .Select(x => x.FileName);

            if (pdfs == null || pdfs.Count() < 2)
            {
                MessageBox.Show("Please select at least two pdf files", "Merging error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (PdfDocument outPdf = new PdfDocument())
                {
                    foreach (var document in pdfs)
                    {
                        document.Replace(@"\", "/");
                        PdfDocument importPdf = PdfReader.Open(document, PdfDocumentOpenMode.Import);
                        CopyPages(importPdf, outPdf);
                    }
                    var outputLocation = savePath.Replace(@"\", "/");
                    outPdf.Save(outputLocation);
                }

                richConsole.AppendText(string.Format("Merged successfully!\n"));
            }
            catch (Exception ex)
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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            CreateInitialSelectors();
            richConsole.Clear();
        }


        #region Drag Handling

        private void DragEnter_Handler(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.FileDrop) &&
               ((string[])e.Data.GetData(DataFormats.FileDrop)).All(f => f.ToLower().Contains(".pdf")))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DragDrop_Handler(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            foreach (string file in files)
            {
                FillOrAddFile(file);
            }

        }

        private void FillOrAddFile(string file)
        {
            PdfSelectorControl lastEmptyPdfSelector = GetFirstEmptyPDFSelector();

            if (lastEmptyPdfSelector == null)
            {
                AddMoreFiles_Click(null, null);
                lastEmptyPdfSelector = GetFirstEmptyPDFSelector();
            }

            lastEmptyPdfSelector.SetFileName(file);
        }

        private PdfSelectorControl GetFirstEmptyPDFSelector()
        { 
            PdfSelectorControl result = null;

            foreach (Control control in panel1.Controls)
            {
                if (control.GetType().Name.Equals("PdfSelectorControl"))
                {
                    result = (PdfSelectorControl)control;
                    if (string.IsNullOrEmpty(result.FileName))
                    {
                        break;
                    }
                    else
                    {
                        result = null;
                    }
                }
            }

            return result;
        }



        #endregion

    }
}
