﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Configuration;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    public class DataProvider
    {
        //private const string ConnectionString = @"Database=callback; Data Source=hoster.hitek.ru; User Id=callback; Password=c9PuRNNAZ7hQ8see";
        static string ConnectionString = ConfigurationManager.ConnectionStrings["CallBack"].ConnectionString;

        public static DataSet GetCallBack()
        {
            const string QueryString = "SELECT * from callback.callback";            
            var ds = new DataSet();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                dataAdapter.Fill(ds);
            }

            return ds;
        }

        public static DataSet GetAuthorizationData(string login, string pass)
        {
            string QueryString = "SELECT * from callback.authorization where user='" + login + "' and pass='" + pass + "'"; 
            var ds = new DataSet();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                dataAdapter.Fill(ds);
            }

            return ds;
        }

        public static void UpdateCallBack(BindingSource bindingSource)
        {
            const string QueryString = "SELECT * from callback.callback";
            bindingSource.EndEdit();

            var ds = (DataSet)bindingSource.DataSource;

            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                dataAdapter.UpdateCommand = new MySqlCommandBuilder(dataAdapter).GetUpdateCommand();
                dataAdapter.Update(ds);
            }
        }
    }
}
