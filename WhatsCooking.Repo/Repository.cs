using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsCooking.Repo.Context;

namespace WhatsCooking.Repo
{
        public class Repository<T> : IRepository<T> where T : class
        {
            private readonly ApplicationDbContext _db;
            private readonly DbSet<T> _table = null;
            public Repository(ApplicationDbContext db)
            {
                _db = db;
                _table = _db.Set<T>();
            }
            public async Task Commit()
            {
                await _db.SaveChangesAsync();
            }

            public async Task Delete(T entity)
            {
                _table.Remove(entity);
                await _db.SaveChangesAsync();
            }

            public async Task DeleteWithNoSave(T entity)
            {
                await Task.Run(() =>
                {
                    _table.Remove(entity);
                });
            }

            public async Task<T> Get(int id)
            {
                return await _table.FindAsync(id);
            }

            public async Task<T> Get(Guid id)
            {
                return await _table.FindAsync(id);
            }

            public async Task<IEnumerable<T>> GetAll()
            {
                return await _table.ToListAsync();
            }

            public async Task<T> Insert(T entity)
            {
                var item = await _table.AddAsync(entity);
                await _db.SaveChangesAsync();
                return item.Entity;
            }

            public async Task<T> InsertWithNoSave(T entity)
            {
                var item = await _table.AddAsync(entity);
                return item.Entity;
            }

        }
}
