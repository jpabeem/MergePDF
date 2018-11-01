using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class PdfSelectorControl : UserControl
    {
        private int _index;
        private Button button;

        private Button closeButton;
        private readonly OpenFileDialog openFileDialog;

        private TextBox textBox;

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

            CreateTextbox();
            CreateCloseButton();
            CreateOpenButton();

            Index = index;

            Controls.Add(textBox);
            Controls.Add(button);
            Controls.Add(closeButton);
        }

        public string FileName { get; private set; }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                if (button != null)
                    button.Text = $"Browse file {_index}";
            }
        }

        public event Action<int> RemoveFile;

        public void OpenFileSelection()
        {
            button.PerformClick();
        }

        private void CreateCloseButton()
        {
            closeButton = new Button
            {
                Location = new Point(510, 0),
                Text = "X",
                Size = new Size(20, 20),
                Visible = true
            };

            closeButton.Click += (sender, e) => { OnRemoveFile(Index); };
        }

        private void CreateTextbox()
        {
            textBox = new TextBox
            {
                Location = new Point(126, 0),
                Size = new Size(380, 20),
                Visible = true,
                ReadOnly = true
            };

            textBox.TextChanged += (sender, e) =>
            {
                if (closeButton != null)
                    closeButton.Enabled = !string.IsNullOrWhiteSpace(textBox.Text);
            };
        }


        private void CreateOpenButton()
        {
            button = new Button
            {
                Location = new Point(10, 0),
                Visible = true
            };

            button.Click += (sender, e) =>
            {
                var dialog = openFileDialog;
                if (dialog.ShowDialog() == DialogResult.OK)
                    try
                    {
                        var fileName = dialog.FileName;
                        textBox.Text = fileName;
                        FileName = fileName;
                    }
                    catch (IOException)
                    {
                        MessageBox.Show("Uh-oh, something went wrong. Please try closing all the PDF files you want to import", "Import error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
            };
        }

        protected virtual void OnRemoveFile(int index)
        {
            RemoveFile?.Invoke(index);
        }

        internal void SetFileName(string filename)
        {
            FileName = filename;
            textBox.Text = filename;
        }
    }
}