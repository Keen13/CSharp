using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            FillDate();
            FillMaster();
            FillCar();
            SetupDataGridView();
        }

        private void FillDate()
        {
            var dateTime = DateTime.Today;
            textBox1.Text = dateTime.ToString("d");
        }

        private void FillMaster()
        {
            var dataSet = DataProvider.GetMaster();

            comboBox2.DataSource = dataSet.Tables[0];
            comboBox2.ValueMember = "Master";
        }

        private void FillCar()
        {
            var dataSet = DataProvider.GetCarInfo();

            comboBox1.DataSource = dataSet.Tables[0];
            //comboBox1.DisplayMember = "Model";
            comboBox1.ValueMember = "Brand";
        }

        private void SetupDataGridView()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.Columns[0].Name = "Список работ";
            //DataGridView();
        }

        private void DataGridView()
        {
            var dataSet = DataProvider.GetWorkType();


        }
    }
}
