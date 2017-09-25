using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSlite.Util
{
    public class MongoUtil<U>
    {
        private const string DefaultConnectionstringName = "MongoServerSettings";


        public static string GetDefaultConnectionString()
        {
            return "mongodb://localhost/MongoRepositoryTests";
            //return ConfigurationManager.ConnectionStrings[DefaultConnectionstringName].ConnectionString;
        }

        //public static MongoUtil<T> GetConnectionFromConnectionstring(string connectionstring)
        //{

        //}

        
    }
}
