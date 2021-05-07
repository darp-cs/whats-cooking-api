using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using WhatsCooking.Service.Contracts;
using WhatsCooking.Service.DTO;

namespace WhatsCooking.Service.Mapper
{
    public class Mapper : IMapper
    {
        public async Task<IEnumerable<Recipe>> Map(IEnumerable<Data.Entities.Recipe> recipes)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<Recipe>();
                foreach (var recipe in recipes)
                {
                    returnList.Add(await Map(recipe));
                }
                return returnList;
            });
        }

        public async Task<IEnumerable<Data.Entities.Recipe>> Map(IEnumerable<Service.Recipe> recipes)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<Data.Entities.Recipe>();
                foreach (var recipe in recipes)
                {
                    returnList.Add(await Map(recipe));
                }
                return returnList;
            });
        }

        public async Task<Recipe> Map(Data.Entities.Recipe recipe)
        {
            return await Task.Run(() =>
            {
                return new Recipe
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    Category = recipe.Category,
                    EstimatedCookingTime = recipe.EstimatedCookingTime,
                    IngredientsList = recipe.IngredientsList,
                    IsGlutenFree = recipe.IsGlutenFree,
                    IsVegan = recipe.IsVegan
                };
            });
        }

        public async Task<Data.Entities.Recipe> Map(Service.Recipe recipe)
        {
            return await Task.Run(() =>
            {
                var returnObj = new Data.Entities.Recipe
                {
                   
                    Name = recipe.Name,
                    Category = recipe.Category,
                    EstimatedCookingTime = recipe.EstimatedCookingTime,
                    IngredientsList = recipe.IngredientsList,
                    IsGlutenFree = recipe.IsGlutenFree,
                    IsVegan = recipe.IsVegan
                };
                if (recipe.Id != null)
                    returnObj.Id = int.Parse(recipe.Id.ToString());
                return returnObj;
            });
        }


        public async Task<IEnumerable<UserAccount>> Map(IEnumerable<Data.Entities.User> users)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<UserAccount>();
                foreach (var user in users)
                {
                    returnList.Add(await Map(user));
                }
                return returnList;
            });
        }

        public async Task<IEnumerable<Data.Entities.User>> Map(IEnumerable<UserAccount> users)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<Data.Entities.User>();
                foreach (var user in users)
                {
                    returnList.Add(await Map(user));
                }
                return returnList;
            });
            
        }

        public async Task<UserAccount> Map(Data.Entities.User user)
        {
            return await Task.Run(async () =>
            {
                var returnUser = new UserAccount
                {
                    Id = user.Id,
                    UserId = user.UserId
                };
                returnUser.UserRecipes = await Map(user.UserRecipes);
                return returnUser;
            });
        }

        public async Task<Data.Entities.User> Map(UserAccount user)
        {
            return await Task.Run(async () =>
            {
                var returnUser = new Data.Entities.User
                {
                    Id = user.Id,
                    UserId = user.UserId
                };
                returnUser.UserRecipes = await Map(user.UserRecipes);
                return returnUser;
            });
        }

        public async Task<IEnumerable<UserRecipe>> Map(IEnumerable<Data.Entities.UserRecipe> recipes)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<UserRecipe>();
                foreach (var recipe in recipes)
                {
                    returnList.Add(await Map(recipe));
                }
                return returnList;
            });
        }

        public async Task<IEnumerable<Data.Entities.UserRecipe>> Map(IEnumerable<DTO.UserRecipe> recipes)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<Data.Entities.UserRecipe>();
                foreach (var recipe in recipes)
                {
                    returnList.Add(await Map(recipe));
                }
                return returnList;
            });
        }

        public async Task<UserRecipe> Map(Data.Entities.UserRecipe recipe)
        {
            return await Task.Run(() =>
            {
                return new UserRecipe
                {
                    Id = recipe.Id,
                    Name = recipe.Name,
                    UserId = recipe.UserId,
                    Category = recipe.Category,
                    EstimatedCookingTime = recipe.EstimatedCookingTime,
                    IngredientsList = recipe.IngredientsList,
                    IsGlutenFree = recipe.IsGlutenFree,
                    IsVegan = recipe.IsVegan
                };
            });
        }

        public async Task<Data.Entities.UserRecipe> Map(UserRecipe recipe)
        {
            return await Task.Run(() =>
            {
                var returnObj = new Data.Entities.UserRecipe
                {
                    Name = recipe.Name,
                    Category = recipe.Category,
                    EstimatedCookingTime = recipe.EstimatedCookingTime,
                    IngredientsList = recipe.IngredientsList,
                    IsGlutenFree = recipe.IsGlutenFree,
                    IsVegan = recipe.IsVegan
                };
                if (recipe.UserId != null)
                    returnObj.UserId = Guid.Parse(recipe.UserId.ToString());
                if (recipe.Id != null)
                    returnObj.Id = int.Parse(recipe.Id.ToString());
                return returnObj;
            });
        }

        public async Task<IEnumerable<UserIngredient>> Map(IEnumerable<Data.Entities.UserIngredient> ingredients)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<UserIngredient>();
                foreach (var item in ingredients)
                {
                    returnList.Add(await Map(item));
                }
                return returnList;
            });
        }


        public async Task<IEnumerable<Data.Entities.UserIngredient>> Map(IEnumerable<UserIngredient> ingredients)
        {
            return await Task.Run(async () =>
            {
                var returnList = new List<Data.Entities.UserIngredient>();
                foreach (var item in ingredients)
                {
                    returnList.Add(await Map(item));
                }
                return returnList;
            });
        }

        public async Task<UserIngredient> Map(Data.Entities.UserIngredient ingredient)
        {
            return await Task.Run(() =>
            {
                return new UserIngredient
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    UserId = ingredient.UserId
                };
            });
        }

        public async Task<Data.Entities.UserIngredient> Map(UserIngredient ingredient)
        {
            return await Task.Run(() =>
            {
                var returnItem = new Data.Entities.UserIngredient
                {
                    Name = ingredient.Name
                };
                if (ingredient.Id != null)
                    returnItem.Id = int.Parse(ingredient.Id.ToString());
                if (ingredient.UserId != null)
                    returnItem.UserId = Guid.Parse(ingredient.UserId.ToString());
                return returnItem;
            });
        }
    }
}
