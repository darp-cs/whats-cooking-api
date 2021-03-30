using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Repo.Context;

namespace WhatsCooking.Repo
{
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        private static string DataConnectionString => new DatabaseConfiguration().GetDataConnectionString();

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseSqlServer(DataConnectionString);
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
