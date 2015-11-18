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

        public static string User { get; set; }

        //public static void Authorization()
        //{
        //    var dataSet = DataProvider.GetAuthorizationData();
        //    var result = dataSet.Tables[0].Rows[0]["user"].ToString();
        //    if (result == "root")
        //    {
        //        Status = true;
        //    }
        //}

        //TODO VS: Вроде бы понятно  - этот класс у тебя служит для получения данных из таблицы пользователей и сравнения с введенными.
        // Тогда возникает вопрос к самому классу - зачем ты хранишь Status и User в этом классе? они тебе нужны только при проверке
        //  передавай пользователя в параметрах вызова, статус возвращай из метода.
        public static void ComparisonLoginPass(string login, string pass)
        {
            var dataSet = DataProvider.GetAuthorizationData(); //TODO VS: см комменты в классе

            var table = new DataTable();
            table = dataSet.Tables[0];
            table.PrimaryKey = new[] { table.Columns["user"] };

            var foundRow = dataSet.Tables[0].Rows.Find(login);

            if (foundRow != null && pass == foundRow["pass"].ToString())
            {
                Status = true;
                User = login;
                MessageBox.Show(foundRow["user"].ToString());
            }
            else
            {
                Status = false;
                MessageBox.Show("A row with the primary key of " + login + " could not be found"); //для отладки.
            }
        }
    }
}
