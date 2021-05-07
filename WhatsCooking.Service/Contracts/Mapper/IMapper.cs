using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Service.DTO;

namespace WhatsCooking.Service.Contracts
{
    public interface IMapper
    {

        #region Recipes
        Task<IEnumerable<Recipe>> Map(IEnumerable<WhatsCooking.Data.Entities.Recipe> recipes);
        Task<IEnumerable<WhatsCooking.Data.Entities.Recipe>> Map(IEnumerable<Recipe> recipes);
        Task<Recipe> Map(WhatsCooking.Data.Entities.Recipe recipe);
        Task<WhatsCooking.Data.Entities.Recipe> Map(Recipe recipe);

        #endregion

        #region UserAccounts
        Task<IEnumerable<UserAccount>> Map(IEnumerable<WhatsCooking.Data.Entities.User> users);
        Task<IEnumerable<WhatsCooking.Data.Entities.User>> Map(IEnumerable<UserAccount> users);
        Task<UserAccount> Map(WhatsCooking.Data.Entities.User user);
        Task<WhatsCooking.Data.Entities.User> Map(UserAccount user);

        #endregion

        //TODO: Add in UserRecipes
        Task<IEnumerable<UserRecipe>> Map(IEnumerable<WhatsCooking.Data.Entities.UserRecipe> recipes);
        Task<IEnumerable<WhatsCooking.Data.Entities.UserRecipe>> Map(IEnumerable<UserRecipe> recipes);
        Task<UserRecipe> Map(WhatsCooking.Data.Entities.UserRecipe recipe);
        Task<WhatsCooking.Data.Entities.UserRecipe> Map(UserRecipe recipe);

        #region UserIngredients
        Task<IEnumerable<UserIngredient>> Map(IEnumerable<WhatsCooking.Data.Entities.UserIngredient> ingredients);
        Task<IEnumerable<WhatsCooking.Data.Entities.UserIngredient>> Map(IEnumerable<UserIngredient> ingredients);
        Task<UserIngredient> Map(WhatsCooking.Data.Entities.UserIngredient ingredient);
        Task<WhatsCooking.Data.Entities.UserIngredient> Map(UserIngredient ingredient);

        #endregion
    }
}
