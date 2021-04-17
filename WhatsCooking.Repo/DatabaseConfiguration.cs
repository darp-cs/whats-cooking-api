using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsCooking.Repo
{
    public class DatabaseConfiguration
    {
        private string ConnectionString = "Server=tcp:whatscookingdbserver.database.windows.net,1433;Initial Catalog=whatscookingdb;Persist Security Info=False;User ID=apickrell;Password=Joseph0521$;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public string GetDataConnectionString()
        {
            return this.ConnectionString;
        }

    }
}
