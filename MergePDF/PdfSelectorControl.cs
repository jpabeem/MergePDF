using System.Drawing;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class PdfSelectorControl : UserControl
    {
        private OpenFileDialog openFileDialog;
        public string FileName { get; private set; }
        public int Index { get; }

        TextBox textBox;

        public PdfSelectorControl(int index)
        {
            InitializeComponent();

            openFileDialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",
                Title = "Open PDF file",
                Filter = "PDF files (*.pdf)|*.pdf",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            Index = index;

            CreateTextbox();

            Controls.Add(textBox);
            Controls.Add(CreateOpenButton());
        }

        private void CreateTextbox()
        {
            textBox = new TextBox
            {
                Location = new Point(126, 0),
                Size = new Size(400, 20),
                Visible = true,
                ReadOnly = true
            };
        }

        private Button CreateOpenButton()
        {
            Button button = new Button
            {
                Location = new Point(10, 0),
                Text = $"Browse {Index} file",
                Visible = true
            };

            button.Click += (sender, e) =>
            {
                var dialog = openFileDialog;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string fileName = dialog.FileName;
                        textBox.Text = fileName;
                        FileName = fileName;
                    }
                    catch (System.IO.IOException)
                    {
                        MessageBox.Show("Uh-oh, something went wrong. Please try closing all the PDF files you want to import", "Import error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            return button;
        }
    }
}
