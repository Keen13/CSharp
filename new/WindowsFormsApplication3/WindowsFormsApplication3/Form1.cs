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
            
            AuthorizationData.Status = true;
            dataGridView1.Show();
        }

        private void RefreshDataGridView1()
        {
            var ds = DataProvider.GetCallBack();

            var table = new DataTable();
            table = ds.Tables[0];
            table.DefaultView.RowFilter = "status = 'no'";
            dataGridView1.DataSource = table.DefaultView;
           
            AdjustColumnOrder();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            comboBox1.Items.Clear();
            var numberRows = ds.Tables[0].Rows.Count;
            for (var i = 0; i < numberRows; i++)
            {
                comboBox1.Items.Add(i);
            }

            comboBox1.SelectedIndex = 0;
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

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(comboBox1.SelectedIndex);
        }
    }
}
