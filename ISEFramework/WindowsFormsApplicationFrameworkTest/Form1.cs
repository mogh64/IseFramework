using ISE.Framework.Common.CommonBase;
using ISE.Framework.Common.Logger;
using ISE.Framework.Common.Service;
using IseFrameworkUnitTest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplicationFrameworkTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string original = "1";
            string key = "Ise98765";
            var dest = ISE.Framework.Utility.Utils.Encryption.EncryptUrl(original, key);
            var org = ISE.Framework.Utility.Utils.Encryption.DecryptUrl(dest, key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ClientContext.UserHeaderToken.Add("ActionId", "-1");
            //ClientContext.UserHeaderToken.Add("UserName", "ali");
            //ClientContext.UserHeaderToken.Add("ActionId", "1");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try{
               
                FileLogger.WriteLog("this is test");
                MessageBox.Show("ok");
            }
            catch
            {
                MessageBox.Show("no");
            }
        }
    }
}
