using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Data.Entities;
using WhatsCooking.Repo;
using WhatsCooking.Service.Contracts.Account;
using System.Linq;
namespace WhatsCooking.Service.Services.Account
{
    public class AccountService : IAccountService
    {
        private IRepository<ApplicationUser> _applicationUserRepo;
        public AccountService(IRepository<ApplicationUser> applicationUserRepo)
        {
            _applicationUserRepo = applicationUserRepo;
        }
        public async Task DeleteAccount(string userName)
        {
            var allUsers = await _applicationUserRepo.GetAll();
            var currentUser = allUsers.FirstOrDefault(m => m.UserName == userName);
            await _applicationUserRepo.Delete(currentUser);
        }
    }
}
