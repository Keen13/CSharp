using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGridView1();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var dataSet = DataProvider.GetCarInfo();
            var comparedObj1 = (int)comboBox1.SelectedItem;
            //var comparedObj2 = (int)comboBox2.SelectedItem;
            var row = dataSet.Tables[0].Rows[comparedObj1];
            textBox5.Text = row["Model"].ToString();
            RefreshDataGridView1();
        }

        private void RefreshDataGridView1()
        {
            var ds = DataProvider.GetCarInfo();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            AdjustColumnOrder();

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (var i = 0; i < dataGridView1.RowCount; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }

        private void AdjustColumnOrder()
        {
            dataGridView1.Columns["Owner"].DisplayIndex = 0;
            dataGridView1.Columns["LicenseNumber"].DisplayIndex = 1;
            dataGridView1.Columns["CarId"].Visible = false;
            dataGridView1.Columns["BrandAndModelId"].Visible = false;
            dataGridView1.Columns["BAMId"].Visible = false;
            dataGridView1.Columns["Brand"].DisplayIndex = 2;
            dataGridView1.Columns["Model"].DisplayIndex = 3;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form2 = new Form2();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var form3 = new Form3();
            form3.Show();
        }
        
    }
}
