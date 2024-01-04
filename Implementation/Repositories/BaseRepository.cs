﻿using Backend.Context;
using Backend.Contract;
using Backend.Interface.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Backend.Implementation.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        protected ApplicationContext _context;

        public async Task<T> Register(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression)
        {
            var ans = await _context.Set<T>().FirstOrDefaultAsync(expression);
            return ans;
        }

        public async Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> GetByExpression(Expression<Func<T, bool>> expression)
        {
            var get = await _context.Set<T>().Where(expression).ToListAsync();
            return get;
        }

    }
}
