using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WhatsCooking.Service.Contracts.Account
{
    public interface IAccountService
    {
        public Task DeleteAccount(string userName);
    }
}
