using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsCooking.Repo
{

    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Get(Guid id);
        Task<T> Insert(T entity);
        Task<T> InsertWithNoSave(T entity);
        Task Delete(T entity);
        Task DeleteWithNoSave(T entity);
        Task Commit();
    }
}
