﻿using Microsoft.EntityFrameworkCore;
using SampleTask.Application.Interfaces.Repos;
using SampleTask.Persistence.Context;

namespace SampleTask.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<T> Add(T entity)
        {
            await _context.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
