using PostgresqlExample.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<bool> CheckArticle(int id);
    }
}
