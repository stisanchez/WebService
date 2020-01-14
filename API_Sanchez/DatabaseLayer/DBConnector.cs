using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer
{
    public class DBConnector
    {
        private string connectionString;

        public DBConnector()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DB_MainConnection"].ConnectionString;
        }
    }
}
