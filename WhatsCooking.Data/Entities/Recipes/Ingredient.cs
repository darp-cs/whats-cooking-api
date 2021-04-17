using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhatsCooking.Data.Entities.Recipes
{
    public class Ingredient
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
