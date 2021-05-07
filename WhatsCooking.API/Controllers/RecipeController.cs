using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsCooking.Service;
using WhatsCooking.Service.Contracts;

namespace WhatsCooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : Controller
    {
        private readonly IRecipeService _recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRecipes()
        {
            return Ok(await _recipeService.GetAllRecipes());
        }

        [HttpGet("category/{name}")]
        public async Task<IActionResult> GetRecipesByCategory(string name)
        {
            return Ok(await _recipeService.GetRecipesByCategory(name));
        }

        [HttpPost]
        public async Task<IActionResult> AddRecipe(Recipe recipe)
        {
            return Ok(await _recipeService.AddOrUpdateRecipe(recipe));
        }
        


    }
}
