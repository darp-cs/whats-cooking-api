using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Service.DTO;

namespace WhatsCooking.Service.Contracts
{
    public interface IUserRecipeService
    {
        public Task<IEnumerable<UserRecipe>> GetUserRecipesByUsername(string email);
        public Task<UserRecipe> AddOrUpdateUserRecipe(UserRecipe recipe, string userName);
        public Task DeleteUserRecipe(int recipeId, string username);
        public Task<UserRecipe> GetUserRecipeById(int id, string userName);
    }
}
