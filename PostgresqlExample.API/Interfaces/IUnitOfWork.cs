using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IArticleRepository ArticleRepository { get; }

        Task<bool> CompleteAsync();
    }
}
