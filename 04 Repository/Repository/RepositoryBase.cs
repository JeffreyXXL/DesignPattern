using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _04_Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class, IEntity, new()
    {
        public Task<bool> DeleteByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> InsertAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> QuerySingleAsync(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
