using PostgresqlExample.Data.Context;
using PostgresqlExample.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PostgresqlExampleDbContext _context;

        public IArticleRepository ArticleRepository { get; private set; }

       
        public UnitOfWork(PostgresqlExampleDbContext Context)
        {
            _context = Context;
            ArticleRepository = new ArticleRepository(_context);
        }

        public async Task<bool> CompleteAsync()
        {
            await _context.SaveChangesAsync();
            return true;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
