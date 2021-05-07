using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Repo;
using WhatsCooking.Service.Contracts;
using WhatsCooking.Service.DTO;
using System.Linq;
namespace WhatsCooking.Service.Services
{
    public class UserRecipeService : IUserRecipeService
    {
        private readonly IRepository<WhatsCooking.Data.Entities.UserRecipe> _userRecipeRepo;
        private readonly IRepository<WhatsCooking.Data.Entities.ApplicationUser> _applicationUserRepo;
        private readonly IMapper _mapper;
        public UserRecipeService(IRepository<WhatsCooking.Data.Entities.UserRecipe> userRecipeRepo, IMapper mapper, IRepository<WhatsCooking.Data.Entities.ApplicationUser> applicationUserRepo)
        {
            _userRecipeRepo = userRecipeRepo;
            _mapper = mapper;
            _applicationUserRepo = applicationUserRepo;
        }
        public async Task<UserRecipe> AddOrUpdateUserRecipe(UserRecipe recipe, string userName)
        {
            if (recipe.Id == null)
            {
                var allUsers = await _applicationUserRepo.GetAll();
                recipe.UserId = Guid.Parse(allUsers.FirstOrDefault(m => m.UserName == userName).Id);
                // new insertion
                return await (_mapper.Map(await _userRecipeRepo.Insert(await _mapper.Map(recipe))));
            }
            else
            {
                var oldRecipe = await _userRecipeRepo.Get(int.Parse(recipe.Id.ToString()));
                oldRecipe.Id = int.Parse(recipe.Id.ToString());
                oldRecipe.Name = recipe.Name;
                oldRecipe.UserId = Guid.Parse(recipe.UserId.ToString());
                oldRecipe.EstimatedCookingTime = recipe.EstimatedCookingTime;
                oldRecipe.IngredientsList = recipe.IngredientsList;
                oldRecipe.IsGlutenFree = recipe.IsGlutenFree;
                oldRecipe.IsVegan = recipe.IsVegan;
                oldRecipe.Category = recipe.Category;
                return await _mapper.Map(oldRecipe);
            }
        }

        public async Task DeleteUserRecipe(int recipeId, string userName)
        {
            var allUsers = await _applicationUserRepo.GetAll();
            var currentUser = allUsers.FirstOrDefault(u => u.Email == userName);
            var recipe = await _userRecipeRepo.Get(recipeId);
            if (recipe.UserId != Guid.Parse(currentUser.Id))
                throw new Exception("Cannot find recipe");
            await _userRecipeRepo.Delete(recipe);
        }

        public async Task<UserRecipe> GetUserRecipeById(int id, string userName)
        {
            var allusers = await _applicationUserRepo.GetAll();
            var currentUser = allusers.FirstOrDefault(m => m.Email == userName);
            var recipe = await _userRecipeRepo.Get(id);
            if (recipe.UserId == Guid.Parse(currentUser.Id))
                return await _mapper.Map(recipe);
            else
                throw new Exception("Cannot find recipe");
        }

        public async Task<IEnumerable<UserRecipe>> GetUserRecipesByUsername(string email)
        {
            var allUsers = await _applicationUserRepo.GetAll();
            var allRecipes = await _userRecipeRepo.GetAll();
            var currentUser = allUsers.FirstOrDefault(u => u.Email == email);
            return await _mapper.Map(allRecipes.Where(r => r.UserId == Guid.Parse(currentUser.Id)));
        }
    }
}
