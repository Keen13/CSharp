using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public class DataProvider
    {
        private const string ConnectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\zlodey\CSharp\WindowsFormsApplication1\WindowsFormsApplication1\STOCar.mdf;Integrated Security=True";
        private const string BrandAndModelSelectCommand = "SELECT * from dbo.BrandAndModel";

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
    }
}
