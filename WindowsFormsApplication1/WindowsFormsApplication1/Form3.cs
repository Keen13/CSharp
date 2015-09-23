using System;
using System.Data;
using System.Linq;
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
            AddComboBoxColumns();
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

            comboBox1.DataSource = dataSet.Tables[0].AsEnumerable().Select(dataRow => CreateCarInfo(dataRow)).ToList();
        }

        private CarInfo CreateCarInfo(DataRow dataRow)
        {
            return new CarInfo
            {
                BrandAndModel = new BrandAndModel 
                { 
                    BrandCar = dataRow["Brand"].ToString(),
                    ModelCar = dataRow["Model"].ToString() 
                },
                OwnerCar = dataRow["Owner"].ToString(),
                StateNumberCar = dataRow["LicenseNumber"].ToString()
            };
        }

        private void AddComboBoxColumns()
        {
            DataGridViewComboBoxColumn comboboxColumn;
            comboboxColumn = CreateComboBoxColumn();
            SetAlternateChoicesUsingDataSource(comboboxColumn);
            dataGridView1.Columns.Insert(0, comboboxColumn);
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn()
        {
            var column = new DataGridViewComboBoxColumn();
            {
                column.HeaderText = "Список работ";
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }

            return column;
        }

        private void SetAlternateChoicesUsingDataSource(DataGridViewComboBoxColumn comboboxColumn)
        {
            {
                comboboxColumn.DataSource = DataProvider.GetWorkType();
                comboboxColumn.ValueMember = "WorkType";
                comboboxColumn.DisplayMember = comboboxColumn.ValueMember;
            }
        }
    }
}
