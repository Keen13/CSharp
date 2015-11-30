using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Collections;

using MySql.Data.MySqlClient;

namespace WindowsFormsApplication3
{
    //TODO VS: отдельный класс провайдера данных - это круто.  строка соединения хардкодом в  коде - не круто.
    public class DataProvider
    {
        private const string ConnectionString = @"Database=callback; Data Source=hoster.hitek.ru; User Id=callback; Password=c9PuRNNAZ7hQ8see";
//        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\z1\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";

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
    }
}
