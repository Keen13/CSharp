using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            AuthorizationData.Status = false;  //////////////где это прописать...
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = textBox1.Text;
            var pass = textBox2.Text;
            AuthorizationData.ComparisonLoginPass(login, pass);
            //AuthorizationData.Status = true;
            var result = AuthorizationData.Status;
            if (result)
            {
                var form1 = Owner as Form1;
                form1.dataGridView1.Show();
                Close();
            }
        }
    }
}
