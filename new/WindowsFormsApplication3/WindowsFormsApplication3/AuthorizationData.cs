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
        public static bool Status { get; set; }

        //public static void Authorization()
        //{
        //    var dataSet = DataProvider.GetAuthorizationData();
        //    var result = dataSet.Tables[0].Rows[0]["user"].ToString();
        //    if (result == "root")
        //    {
        //        Status = true;
        //    }
        //}

        public static void ComparisonLoginPass(string login, string pass)
        {
            var dataSet = DataProvider.GetAuthorizationData();

            var table = new DataTable();
            table = dataSet.Tables[0];
            table.PrimaryKey = new[] { table.Columns["user"] };

            var foundRow = dataSet.Tables[0].Rows.Find(login);

            if (foundRow != null && pass == foundRow["pass"].ToString())
            {
                Status = true;
                MessageBox.Show(foundRow["user"].ToString());
            }
            else
            {
                Status = false;
                MessageBox.Show("A row with the primary key of " + login + " could not be found");
            }
        }
    }
}
