using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DataProvider
    {
        //private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\zlodey\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\z1\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";
        private const string BrandAndModelSelectCommand = "SELECT * from dbo.BrandAndModel";
        private const string WorkTypeSelectCommand = "SELECT * from dbo.WorkType";


        private static List<CarInfo> GetListBrandAndModel()
        {
            const string QueryString = "SELECT * from dbo.HandbookCar hc join dbo.BrandAndModel bm on hc.BrandAndModelId=bm.BAMId";
            var listCarInfo = new List<CarInfo>();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var command = new SqlCommand(QueryString, connection);

                try
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        //var data = string.Format("{0}, {1}, {2}, {3}", reader["Owner"], reader["LicenseNumber"], reader["Brand"], reader["Model"]);
                        //var x = 0;

                        listCarInfo.Add(
                            new CarInfo
                            {
                                BrandAndModel = new BrandAndModel
                                {
                                    BrandCar = reader["Brand"].ToString(),
                                    ModelCar = (string)reader["Model"],
                                },
                                StateNumberCar = reader["LicenseNumber"].ToString(),
                                OwnerCar = reader["Owner"].ToString()
                            });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return listCarInfo;
        }

        public static DataSet GetCarInfo()
        {
            const string QueryString = "SELECT * from dbo.HandbookCar hc join dbo.BrandAndModel bm on hc.BrandAndModelId=bm.BAMId";
            var ds = new DataSet();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(QueryString, connection);
                dataAdapter.Fill(ds);
            }

            return ds;
        }

        public static DataTable GetBrandAndModel()
        {
            var table = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(BrandAndModelSelectCommand, connection);
                dataAdapter.Fill(table);
            }

            return table;
        }

        public static void UpdateBrandAndModel(BindingSource bindingSource)
        {
            bindingSource.EndEdit();

            var dt = (DataTable)bindingSource.DataSource;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(BrandAndModelSelectCommand, connection);
                dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                dataAdapter.Update(dt);
            }
        }

        public static DataTable GetWorkType()
        {
            var table = new DataTable();

            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(WorkTypeSelectCommand, connection);
                dataAdapter.Fill(table);
            }

            return table;
        }

        public static void UpdateWorkType(BindingSource bindingSource)
        {
            bindingSource.EndEdit();

            var dt = (DataTable)bindingSource.DataSource;

            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(WorkTypeSelectCommand, connection);
                dataAdapter.UpdateCommand = new SqlCommandBuilder(dataAdapter).GetUpdateCommand();
                dataAdapter.Update(dt);
            }
        }
    }
}
