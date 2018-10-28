namespace MergePDF
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.lbl_about = new System.Windows.Forms.Label();
            this.llbl_github = new System.Windows.Forms.LinkLabel();
            this.btn_close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_about
            // 
            this.lbl_about.Location = new System.Drawing.Point(12, 9);
            this.lbl_about.Name = "lbl_about";
            this.lbl_about.Size = new System.Drawing.Size(319, 29);
            this.lbl_about.TabIndex = 0;
            this.lbl_about.Text = "MergePDF is an open source tool that combines multiple pdf files into a single pd" +
    "f. Read more here:";
            this.lbl_about.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // llbl_github
            // 
            this.llbl_github.Location = new System.Drawing.Point(76, 48);
            this.llbl_github.Name = "llbl_github";
            this.llbl_github.Size = new System.Drawing.Size(197, 23);
            this.llbl_github.TabIndex = 1;
            this.llbl_github.TabStop = true;
            this.llbl_github.Text = "https://github.com/jpabeem/MergePDF";
            this.llbl_github.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbl_github_LinkClicked);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(138, 74);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(75, 23);
            this.btn_close.TabIndex = 2;
            this.btn_close.Text = "OK";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 115);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.llbl_github);
            this.Controls.Add(this.lbl_about);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_about;
        private System.Windows.Forms.LinkLabel llbl_github;
        private System.Windows.Forms.Button btn_close;
    }
}