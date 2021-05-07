using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Service.DTO;

namespace WhatsCooking.Service.Contracts
{
    public interface IUserIngredientService
    {
        Task<UserIngredient> AddUserIngredient(UserIngredient ingredient, string username);
        Task<IEnumerable<UserIngredient>> GetUserIngredients(string userName);
        Task DeleteUserIngredient(int ingredientId);
    }
}
