using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace readMail
{
    public partial class baseSet : Form
    {
        public baseSet()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt_usn.Text = DataSecurity.DES3Encrypt(txt_regUrl.Text,"jioljkok","qnsowlxh","inwdonda");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txt_usn.Text = DataSecurity.DES3Decrypt(txt_usn.Text,"jioljkok","qnsowlxh","inwdonda");
        }
    }
}
