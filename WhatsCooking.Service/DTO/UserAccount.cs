using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsCooking.Service
{
    public class UserAccount
    {
        public Guid Id { get; set; }
        // userID maps to identity user object
        public Guid UserId { get; set; }
        public IEnumerable<Recipe> UserRecipes { get; set; }
    }
}
