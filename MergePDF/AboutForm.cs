using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MergePDF
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void llbl_github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/jpabeem/MergePDF");
        }
    }
}
