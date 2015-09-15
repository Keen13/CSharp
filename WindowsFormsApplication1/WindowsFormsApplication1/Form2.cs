using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private readonly BindingSource _bindingSourceBrandAndModel = new BindingSource();
        private readonly BindingSource _bindingSourceWorkType = new BindingSource();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProvider.UpdateBrandAndModel(_bindingSourceBrandAndModel);
            RefreshDataGridView1();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            RefreshDataGridView1();
            RefreshDataGridView2();
        }

        private void RefreshDataGridView1()
        {
            var dataTable = DataProvider.GetBrandAndModel();
            _bindingSourceBrandAndModel.DataSource = dataTable;
            dataGridView1.DataSource = _bindingSourceBrandAndModel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataProvider.UpdateWorkType(_bindingSourceWorkType);
            RefreshDataGridView2();
        }
        
        private void RefreshDataGridView2()
        {
            var dataTable = DataProvider.GetWorkType();
            _bindingSourceWorkType.DataSource = dataTable;
            dataGridView2.DataSource = _bindingSourceWorkType;
        }
    }
}
