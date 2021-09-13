using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PostgresqlExample.Data.Interfaces
{
    public interface IRepository<TModel> where TModel : class
    {
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetById(int id);
        Task<TModel> AddToDb(TModel model);
        Task<TModel> DeleteFromDb(int id);
    }
}
