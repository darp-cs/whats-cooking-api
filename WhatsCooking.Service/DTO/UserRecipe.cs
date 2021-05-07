using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsCooking.Service.DTO
{
    public class UserRecipe
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string IngredientsList { get; set; }
        public Guid? UserId { get; set; }
        public bool IsVegan { get; set; }
        public bool IsGlutenFree { get; set; }
        public string EstimatedCookingTime { get; set; }
    }
}
