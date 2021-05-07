using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WhatsCooking.Service.Contracts
{
    public interface IRecipeService 
    {
        Task<IEnumerable<Recipe>> GetAllRecipes();
        Task<Recipe> AddOrUpdateRecipe(Recipe recipe);
        Task DeleteRecipe(int recipeId);
        Task<IEnumerable<Recipe>> GetRecipesByCategory(string name);
    }
}
