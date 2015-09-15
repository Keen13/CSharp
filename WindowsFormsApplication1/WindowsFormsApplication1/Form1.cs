using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<CarInfo> listCarInfo = new List<CarInfo>();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGridView1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            listBox1.Items.Add("Success");
            //listCarInfo.Add(
            //    new CarInfo
            //    {
            //        BrandAndModel = new BrandAndModel
            //        {
            //            BrandCar = textBox1.Text, 
            //            ModelCar = textBox2.Text,
            //        },
            //        StateNumberCar = textBox3.Text,
            //        OwnerCar = textBox4.Text 
            //    });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var count = listCarInfo.Count;
            listBox1.Items.Add(count);
            listCarInfo.ForEach(PrintList);
        }

        private void PrintList(CarInfo objListCarInfo)
        {

            listBox1.Items.Add(string.Format("Марка {0} Модель {1} Госномер {2} Владелец {3}",
                               objListCarInfo.BrandAndModel.BrandCar, objListCarInfo.BrandAndModel.ModelCar,
                               objListCarInfo.StateNumberCar, objListCarInfo.OwnerCar));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bufer1 = (int)comboBox1.SelectedItem;
            var bufer2 = (int)comboBox2.SelectedItem;
            var result = listCarInfo[bufer1].Equals(listCarInfo[bufer2]);

            textBox5.Text = result ? "Совпадают" : "is not!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RefreshDataGridView1();
            textBox5.Text = dataGridView1["Brand", 1].Value.ToString();
        }

        private void RefreshDataGridView1()
        {
            var ds = DataProvider.GetCarInfo();
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            AdjustColumnOrder();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (var i = 1; i < dataGridView1.RowCount + 1; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
        }

        private void AdjustColumnOrder()
        {
            if (dataGridView1 == null)
            {
                return;
            }

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
    }
}
