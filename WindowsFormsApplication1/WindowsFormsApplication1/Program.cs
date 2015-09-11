using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            ConnectToDb();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void ConnectToDb()
        {
            const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\z1\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";
            const string QueryString = "SELECT * from dbo.HandbookCar";

            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(QueryString, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = string.Format("{0}, {1}, {2}, {3}", reader["Марка"], reader["Модель"], reader["Владелец"], reader["Госномер"]);
                        var x = 0;
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();
            }
        }
    }
}
