using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Repo;
using WhatsCooking.Service.Contracts;
using System.Linq;
namespace WhatsCooking.Service.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRepository<WhatsCooking.Data.Entities.Recipe> _recipeRepo;
        private readonly IMapper _mapper;
        public RecipeService(IRepository<WhatsCooking.Data.Entities.Recipe> recipeRepo, IMapper mapper)
        {
            _recipeRepo = recipeRepo;
            _mapper = mapper;
        }

        public async Task<Recipe> AddOrUpdateRecipe(Recipe recipe)
        {
            // new create
            if (recipe.Id == null)
            {
               var newItem = await _recipeRepo.Insert(await _mapper.Map(recipe));
                return await _mapper.Map(newItem);
            }
                
            else
            {
                var itemToUpdate = await _recipeRepo.Get(int.Parse(recipe.Id.ToString()));
                itemToUpdate.Name = recipe.Name;
                await _recipeRepo.Commit();
                return recipe;
            }
        }

        public async Task DeleteRecipe(int recipeId)
        {
            var itemToDelete = await _recipeRepo.Get(int.Parse(recipeId.ToString()));
            await _recipeRepo.Delete(itemToDelete);

        }

        public async Task<IEnumerable<Service.Recipe>> GetAllRecipes()
        {
            return (await _mapper.Map(await _recipeRepo.GetAll()));
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByCategory(string name)
        {
            var allRecipes = await _recipeRepo.GetAll();
            return await _mapper.Map(allRecipes.Where(r => r.Category.ToLower() == name.ToLower()));
        }
    }
}
