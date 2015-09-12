using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public class DataProvider
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\zlodey\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";

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

        public static DataSet GetBrandAndModel()
        {
            const string QueryString = "SELECT * from dbo.BrandAndModel";
            var ds = new DataSet();
            using (var connection = new SqlConnection(ConnectionString))
            {
                var dataAdapter = new SqlDataAdapter(QueryString, connection);
                dataAdapter.Fill(ds);
            }

            return ds;
        }
    }
}
