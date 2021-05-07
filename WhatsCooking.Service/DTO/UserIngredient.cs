using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsCooking.Service.DTO
{
    public class UserIngredient
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public Guid? UserId { get; set; }
    }
}
