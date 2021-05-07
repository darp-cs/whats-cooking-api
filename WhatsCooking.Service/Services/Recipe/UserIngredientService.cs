using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Repo;
using WhatsCooking.Service.DTO;
using System.Linq;
using WhatsCooking.Service.Contracts;

namespace WhatsCooking.Service.Services
{
    public class UserIngredientService : IUserIngredientService
    {
        public IRepository<Data.Entities.UserIngredient> _ingredientRepo;
        public IRepository<Data.Entities.ApplicationUser> _userRepo;
        public IMapper _mapper;
        public UserIngredientService(IRepository<Data.Entities.UserIngredient> ingredientRepo, IRepository<Data.Entities.ApplicationUser> userRepo, IMapper mapper)
        {
            _ingredientRepo = ingredientRepo;
            _userRepo = userRepo;
            _mapper = mapper;
        }
        public async Task<UserIngredient> AddUserIngredient(UserIngredient ingredient, string username)
        {
            var allUsers = await _userRepo.GetAll();
            var currentUser = allUsers.FirstOrDefault(u => u.Email == username);
            ingredient.UserId = Guid.Parse(currentUser.Id.ToString());
            return await _mapper.Map(await _ingredientRepo.Insert(await _mapper.Map(ingredient)));
            
        }

        public async Task DeleteUserIngredient(int ingredientId)
        {
            var allIngredients = await _ingredientRepo.GetAll();
            await _ingredientRepo.Delete(allIngredients.FirstOrDefault(i => i.Id == ingredientId));
        }

        public async Task<IEnumerable<UserIngredient>> GetUserIngredients(string username)
        {
            var allUsers = await _userRepo.GetAll();
            var allIngredients = await _ingredientRepo.GetAll();
            var currentUser = allUsers.FirstOrDefault(u => u.UserName == username);
            return await _mapper.Map(allIngredients.Where(i => i.UserId == Guid.Parse(currentUser.Id.ToString())));
        }
    }
}
