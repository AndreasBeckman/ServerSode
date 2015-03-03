using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bibliotekServerSideWeb
{
    public class Data
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            set { _connectionString = value; }
            get { return _connectionString; }
        }
    }
}