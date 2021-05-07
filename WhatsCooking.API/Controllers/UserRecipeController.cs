using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsCooking.Service.Contracts;
using WhatsCooking.Service.DTO;
using WhatsCooking.Service.Services;

namespace WhatsCooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserRecipeController : Controller
    {
        private readonly IUserRecipeService _userRecipeService;
        public UserRecipeController(IUserRecipeService userRecipeService)
        {
            _userRecipeService = userRecipeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRecipe(UserRecipe recipe)
        {
            return Ok(await _userRecipeService.AddOrUpdateUserRecipe(recipe, User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUserRecipes()
        {
            return Ok(await _userRecipeService.GetUserRecipesByUsername(User.Identity.Name));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUserRecipeById(int id)
        {
            return Ok(await _userRecipeService.GetUserRecipeById(id, User.Identity.Name));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserRecipe(int id)
        {
            await _userRecipeService.DeleteUserRecipe(id, User.Identity.Name);
            return Ok("Recipe Deleted Successfully");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> EditExistingUserRecipe(UserRecipe recipe)
        {
            return Ok(await _userRecipeService.AddOrUpdateUserRecipe(recipe, User.Identity.Name));
        }

    }
}
