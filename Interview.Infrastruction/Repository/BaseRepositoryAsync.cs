﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interview.ApplicationCore.Contract.Repository;
using Interview.Infrastruction.Data;
using Microsoft.EntityFrameworkCore;

namespace Interview.Infrastruction.Repository
{
    public class BaseRepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        private readonly InterviewDbContext db;
        public BaseRepositoryAsync(InterviewDbContext _context) {
            db = _context;
        }
        public async Task<int> DeleteAsync(int id)
        {
            var entity = await db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                db.Set<T>().Remove(entity);
                return await db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await db.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await db.Set<T>().FindAsync(id);
        }

        public async Task<int> InsertAsync(T entity)
        {
            db.Set<T>().Add(entity);
            return await db.SaveChangesAsync();
        }

        public async Task<int> UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            return await db.SaveChangesAsync();
        }
    }
}
