using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace testapi.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(DataContext dataContext)
        {
            _context = dataContext;
            _dbSet = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null) _dbSet.Remove(entity);
        }


        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();



        public async Task<T> GetByIdAsync(int id) => await _dbSet.FindAsync(id);




        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            _context.SaveChangesAsync();
        }


    }
}