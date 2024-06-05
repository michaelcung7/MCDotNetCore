using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCDotNetCore.WinFormsApp
{
    public partial class FrmMainMenu : Form
    {
        public FrmMainMenu()
        {
            InitializeComponent();
        }

        private void FrmMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void blogToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newBlogToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmBlog frm = new FrmBlog();
            frm.Show();
            //frm.ShowDialog();

        }

        private void blogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBlogList frmBlogList = new FrmBlogList();
            frmBlogList.ShowDialog();

        }
    }
}
