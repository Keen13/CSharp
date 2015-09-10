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
    public partial class Form1 : Form
    {
        List<CarInfo> listCarInfo = new List<CarInfo>();
        CarInfo _carInfo = new CarInfo();

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



    }
}
