﻿using System;
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
            button1.Visible = false;
        }

        private void AdjustColumnOrder()
        {
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["number"].DisplayIndex = 0;
            dataGridView1.Columns["Date"].DisplayIndex = 1;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshDataGridView1();
            dataGridView1.Show();
        }

        private void RefreshDataGridView1()
        {
            var ds = DataProvider.GetCallBack(); 

            var table = new DataTable(); 
            table = ds.Tables[0];

            if (checkWotchStatus.Checked)
            {
                table.DefaultView.RowFilter = "status = 'no'";
            }
            else
            {
                table.DefaultView.RowFilter = "status > ''";
            }
            
            dataGridView1.DataSource = table.DefaultView;
           
            AdjustColumnOrder();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                return;
            }

            var rowIndex = dataGridView1.CurrentRow.Index;
            var newStatus = (DataGridViewTextBoxCell)dataGridView1.Rows[rowIndex].Cells["status"];
            newStatus.Value = "yes";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text;
            var pass = passwordTextBox.Text;
            if (AuthorizationData.ComparisonLoginPass(login, pass))
            {
                dataGridView1.Show();
                button1.Visible = true;
                loginTextBox.Hide();
                passwordTextBox.Hide();
                buttonAuthorization.Visible = false;
            }
        }
    }
}
