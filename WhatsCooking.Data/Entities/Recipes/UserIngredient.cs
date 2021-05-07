using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WhatsCooking.Data.Entities
{
    public class UserIngredient
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid UserId { get; set; }
    }
}
