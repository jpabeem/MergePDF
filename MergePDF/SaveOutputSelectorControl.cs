using System;
using System.Drawing;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class SaveOutputSelectorControl : UserControl
    {
        public string FileName { get; private set; }
        private SaveFileDialog saveFileDialog;
        private readonly Action<string> logger;

        TextBox textBox;

        public SaveOutputSelectorControl(Action<string> logger)
        {
            InitializeComponent();

            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = "c:\\";
            saveFileDialog.Title = "Save merged PDF file at";
            saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            CreateTextbox();

            Controls.Add(textBox);
            Controls.Add(CreateSaveButton());
            this.logger = logger;
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

        private Button CreateSaveButton()
        {
            Button button = new Button
            {
                Location = new Point(10, 0),
                Text = string.Format("Save file at"),
                Visible = true
            };

            button.Click += (sender, e) =>
            {
                saveFileDialog.ShowDialog();
                if (saveFileDialog.FileName != "")
                {
                    textBox.Text = saveFileDialog.FileName;
                    FileName = saveFileDialog.FileName;
                    logger?.Invoke($"Output location set: {saveFileDialog.FileName}\n");
                }
            };

            return button;
        }
    }
}