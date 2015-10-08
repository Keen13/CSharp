using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class AuthorizationData
    {
        public static bool Status { get; set; }

        public AuthorizationData()
        {
            var dataSet = DataProvider.GetAuthorizationData();
            var result = dataSet.Tables[0].Rows[0]["user"].ToString();
            if (result == "root")
            {
                Status = true;
            }
        }
    }
}
