using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Core.DataAccessContracts
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> Get(CancellationToken cancellationToken);
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task<T> Get(int id, CancellationToken cancellationToken);
        Task<int> Create(T entity, CancellationToken cancellationToken);
        Task Update(T entity, CancellationToken cancellationToken);
        Task Update(Expression<Func<T, bool>> filter, T entity, CancellationToken cancellationToken);
        Task Delete(int id, CancellationToken cancellationToken);
        Task Delete(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
        Task DeleteManyAsync(IEnumerable<T> collection, CancellationToken cancellationToken);
    }
}