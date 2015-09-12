using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        private readonly BindingSource _bindingSource = new BindingSource();
        
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataProvider.UpdateBrandAndModel(_bindingSource);
            var dataTable = DataProvider.GetBrandAndModel();
            _bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = _bindingSource;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            var dataTable = DataProvider.GetBrandAndModel();
            _bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = _bindingSource;
        }
    }
}
