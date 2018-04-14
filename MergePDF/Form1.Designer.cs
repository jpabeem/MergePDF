namespace MergePDF
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnMergePdf = new System.Windows.Forms.Button();
            this.richConsole = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblMergeAmount = new System.Windows.Forms.Label();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMergePdf
            // 
            this.btnMergePdf.Location = new System.Drawing.Point(12, 311);
            this.btnMergePdf.Name = "btnMergePdf";
            this.btnMergePdf.Size = new System.Drawing.Size(604, 23);
            this.btnMergePdf.TabIndex = 0;
            this.btnMergePdf.TabStop = false;
            this.btnMergePdf.Text = "Merge PDF";
            this.btnMergePdf.UseVisualStyleBackColor = true;
            this.btnMergePdf.Click += new System.EventHandler(this.btnMergePdf_Click);
            // 
            // richConsole
            // 
            this.richConsole.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.richConsole.Location = new System.Drawing.Point(12, 373);
            this.richConsole.Name = "richConsole";
            this.richConsole.ReadOnly = true;
            this.richConsole.Size = new System.Drawing.Size(604, 96);
            this.richConsole.TabIndex = 1;
            this.richConsole.Text = "";
            this.richConsole.TextChanged += new System.EventHandler(this.richConsole_TextChanged);
            this.richConsole.Enter += new System.EventHandler(this.richConsole_Enter);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(628, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "2",
            "3",
            "4"});
            this.comboBox1.Location = new System.Drawing.Point(12, 63);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(604, 21);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // lblMergeAmount
            // 
            this.lblMergeAmount.AutoSize = true;
            this.lblMergeAmount.Location = new System.Drawing.Point(9, 47);
            this.lblMergeAmount.Name = "lblMergeAmount";
            this.lblMergeAmount.Size = new System.Drawing.Size(213, 13);
            this.lblMergeAmount.TabIndex = 4;
            this.lblMergeAmount.Text = "How many PDF files do you want to merge?";
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(12, 340);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(604, 23);
            this.btnClearAll.TabIndex = 5;
            this.btnClearAll.TabStop = false;
            this.btnClearAll.Text = "Clear all fields";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 481);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.lblMergeAmount);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.richConsole);
            this.Controls.Add(this.btnMergePdf);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MergePDF";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMergePdf;
        private System.Windows.Forms.RichTextBox richConsole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblMergeAmount;
        private System.Windows.Forms.Button btnClearAll;
    }
}

