using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<CarInfo> listCarInfo = new List<CarInfo>();
        CarInfo _carInfo = new CarInfo();

        const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\zlodey\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";
        const string QueryString = "SELECT * from dbo.HandbookCar";

        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = !checkBox1.Checked;
            listBox1.Items.Add("aaaa");
            _carInfo.BrandCar = textBox1.Text;
            _carInfo.ModelCar = textBox2.Text;
            _carInfo.StateNumberCar = textBox3.Text;
            _carInfo.OwnerCar = textBox4.Text;
            listCarInfo.Add(new CarInfo(){ BrandCar = textBox1.Text, ModelCar = textBox2.Text,
                                          StateNumberCar = textBox3.Text,OwnerCar = textBox4.Text });

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            for (var i = 0; i < listCarInfo.Count; i++)
            {
                comboBox1.Items.Add(i);
                comboBox2.Items.Add(i);
            }
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
                               objListCarInfo.BrandCar, objListCarInfo.ModelCar,
                               objListCarInfo.StateNumberCar, objListCarInfo.OwnerCar));
        }



        private bool Compare(CarInfo objListCarInfo1, CarInfo objListCarInfo2)
        {
            var resultBrandCar = objListCarInfo1.BrandCar.Equals(objListCarInfo2.BrandCar);
            var resultModelCar = objListCarInfo1.ModelCar.Equals(objListCarInfo2.ModelCar);

            return resultBrandCar && resultModelCar;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var bufer1 = int.Parse(comboBox1.SelectedItem.ToString());
            var bufer2 = int.Parse(comboBox2.SelectedItem.ToString());
            var result = Compare(listCarInfo[bufer1], listCarInfo[bufer2]);

            textBox5.Text = result ? "Совпадают" : "is not!";
        }

        private void button4_Click(object sender, EventArgs e) // ???
        {
            var connection = new SqlConnection(ConnectionString);

            connection.Disposed += new EventHandler(conn_Disposed);
            connection.StateChange += new StateChangeEventHandler(conn_StateChange);

            var dataAdapter = new SqlDataAdapter(QueryString, connection);
            var ds = new DataSet();

            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            connection.Dispose();
        }

        private void conn_Disposed(object sender, EventArgs e)
        {
            label2.Text += "Событие Dispose"; 
        }

        private void conn_StateChange(object sender, StateChangeEventArgs e)
        {
               label1.Text+="\nИсходное состояние: "+e.OriginalState.ToString() + "\n Текущее состояние: "+ e.CurrentState.ToString(); 
        }


    }

}
