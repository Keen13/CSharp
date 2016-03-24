using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Configuration;

using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public class DataProvider
    {
        //private const string ConnectionString = @"Database=callback; Data Source=hoster.hitek.ru; User Id=callback; Password=c9PuRNNAZ7hQ8see";
        static string ConnectionString = ConfigurationManager.ConnectionStrings["CallBack"].ConnectionString;

        public static DataTable GetCallBackData()
        {
            const string QueryString = "SELECT * from callback.callback";
            var table = new DataTable();
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                dataAdapter.Fill(table);
            }

            return table;
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
            bindingSource.EndEdit();

            const string QueryString = "SELECT * from callback.callback";
            var dataTable = (DataTable)bindingSource.DataSource;
            using (var connection = new MySqlConnection(ConnectionString))
            {
                var dataAdapter = new MySqlDataAdapter(QueryString, connection);
                dataAdapter.UpdateCommand = new MySqlCommandBuilder(dataAdapter).GetUpdateCommand();
                dataAdapter.Update(dataTable);
            }
        }
    }
}
