using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WhatsCooking.Data.Entities;

namespace WhatsCooking.Repo.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> UserAccounts { get; set; }
        public DbSet<UserRecipe> UserRecipes { get; set; }
        public DbSet<UserIngredient> UserIngredients {get; set;}
    }
}
