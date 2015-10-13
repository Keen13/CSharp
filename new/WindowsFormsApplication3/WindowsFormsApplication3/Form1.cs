using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshDataGridView1();
            dataGridView1.Hide();
        }

        private void AdjustColumnOrder()
        {
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["number"].DisplayIndex = 0;
            dataGridView1.Columns["Date"].DisplayIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGridView1();
        }

        private void RefreshDataGridView1()
        {
            var ds = DataProvider.GetCallBack();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            AdjustColumnOrder();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Owner = this;
            form2.ShowDialog();
        }
    }
}
