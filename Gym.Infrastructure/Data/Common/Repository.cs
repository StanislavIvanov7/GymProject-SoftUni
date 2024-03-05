using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gym.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext _context)
        {
                context = _context;
        }

        private DbSet<T> DbSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllAsReadOnly<T>() where T : class
        { 
            return DbSet<T>()
                .AsNoTracking();
        }

        public async Task AddAsync<T>(T entity) where T : class
        {
             await DbSet<T>().AddAsync(entity);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Delete<T>(T entity) where T : class
        {
             DbSet<T>().Remove(entity);
        }

        public async Task<T?> GetByIdAsync<T>(int id) where T : class
        {
            return await DbSet<T>().FindAsync(id);
        }
    }
}
