using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOAPCAT
{
    public class DBHelper
    {
        private string connectionString = @"Data Source=students-server.database.windows.net;Initial Catalog=""Cat's"";Integrated Security=False;User ID=chri56a4;Password=K03g3bugt;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public static List<Cat> GetAllCats()
        {
            
            return null;
        }
    }
}