using Microsoft.EntityFrameworkCore;
using PostgresqlExample.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Repositories
{
    public class Repository<TModel> : IRepository<TModel> where TModel : class
    {
        protected DbContext _context;
        private readonly DbSet<TModel> _dbSet;
        
        

        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TModel>();
        }

        public async Task<TModel> AddToDb(TModel model)
        {
            await _dbSet.AddAsync(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<TModel> DeleteFromDb(int id)
        {
            TModel result = await _dbSet.FindAsync(id);
            _dbSet.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }

        public async Task<IEnumerable<TModel>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TModel> GetById(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }
    }
}
