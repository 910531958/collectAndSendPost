using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace readMail
{
    public partial class index : Form
    {
        public index()
        {
            InitializeComponent();
        }

        private void index_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("56lea.com");
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            winManager.getThis().bsWin.Show();
        }
    }
}
