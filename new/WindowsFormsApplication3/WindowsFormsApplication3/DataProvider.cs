﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    //TODO VS: отдельный класс провайдера данных - это круто.  строка соединения хардкодом в  коде - не круто.
    public class DataProvider
    {
        private const string ConnectionString = @"Database=callback; Data Source=hoster.hitek.ru; User Id=callback; Password=c9PuRNNAZ7hQ8see";
        //private const string QueryString = "SELECT * from callback.callback";

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

        public static DataSet GetAuthorizationData()
        {
            const string QueryString = "SELECT * from callback.authorization"; //TODO VS:  зачем ты выгребаешь всю таблицу каждый раз?
            // у тебя уже есть имя и пароль,  делай выборку по ним - либо в таблицк есть такая строка, либо нет
            var ds = new DataSet();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                dataAdapter.Fill(ds);
            }

            return ds;
        }
    }
}
