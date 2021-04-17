using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhatsCooking.Data.Entities.Recipes
{
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
