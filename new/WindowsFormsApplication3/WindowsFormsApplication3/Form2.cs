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
            AuthorizationData.Status = false;  //////////////где это прописать... // TODO VS: А что это такое? что этот класс  и это поле означают /делают?
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text; 
            var pass = passwordTextBox.Text;
            AuthorizationData.ComparisonLoginPass(login, pass); // TODO VS: см. комментарий в классе AuthorizationData
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
