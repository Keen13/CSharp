using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public static class AuthorizationData
    {
        public static bool ComparisonLoginPass(string login, string pass)
        {
            var dataSet = DataProvider.GetAuthorizationData(login, pass); 

            var table = new DataTable();
            table = dataSet.Tables[0];
            table.PrimaryKey = new[] { table.Columns["user"] };

            var foundRow = dataSet.Tables[0].Rows.Find(login);

            if (foundRow != null && pass == foundRow["pass"].ToString())
            {
                //MessageBox.Show(foundRow["user"].ToString());
                return true;
            }
            else
            {
                //MessageBox.Show("A row with the primary key of " + login + " could not be found"); //для отладки.
                return false;
            }
        }
    }
}
