using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WhatsCooking.Service.Contracts;
using WhatsCooking.Service.DTO;

namespace WhatsCooking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserIngredientController : Controller
    {
        private readonly IUserIngredientService _userIngredientService;
        public UserIngredientController(IUserIngredientService userIngredientService)
        {
            _userIngredientService = userIngredientService;
        }
        [HttpPost]
        public async Task<IActionResult> AddUserIngredient(UserIngredient ingredient)
        {
            return Ok(await _userIngredientService.AddUserIngredient(ingredient, User.Identity.Name));
        }

        [HttpGet]
        public async Task<IActionResult> GetUserIngredients()
        {
            return Ok(await _userIngredientService.GetUserIngredients(User.Identity.Name));
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUserIngredient(int id)
        {
            await _userIngredientService.DeleteUserIngredient(id);
            return StatusCode(200);
        }
    }
}
