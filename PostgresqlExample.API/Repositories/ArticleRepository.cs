using PostgresqlExample.Data.Context;
using PostgresqlExample.Data.Entities;
using PostgresqlExample.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Repositories
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        

        public ArticleRepository(PostgresqlExampleDbContext Context) : base(Context)
        {
            //here, we passed PostgresqlExampleDbContext context which comes from DI, to base constructor as base(context)
            //base(context) is the constructor of Repository<Article>.
            
        }
        
        
        
        public async Task<bool> CheckArticle(int id)
        {
           

            var result= await Context.Articles.FindAsync(id);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        //_context is DbContext type. We need to specify that this DbContext is PostgresqlExampleDbContext,
        //Thus we will directly access article table that we have configurated.
        public PostgresqlExampleDbContext Context { get { return _context as PostgresqlExampleDbContext; } }
        //Note that if we do not write public PostgresqlExampleDbContext Context { get { return _context as PostgresqlExampleDbContext; } },
        //We have to use _context like below:
        //_context.FindAsync<Article>(id);
    }
}
