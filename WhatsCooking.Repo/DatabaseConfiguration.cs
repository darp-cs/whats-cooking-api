using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsCooking.Repo
{
    public class DatabaseConfiguration
    {
        private string ConnectionString = "Server=CONNECTION_STRING_HERE;Initial Catalog=HFLDB2;Persist Security Info=False;User ID=apickrell;Password=Joseph0521$;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string GetDataConnectionString()
        {
            return this.ConnectionString;
        }

    }
}
