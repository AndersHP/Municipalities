using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccessContracts;
using Core.Domain;

namespace DAL.InMemoryRepositories
{
    public class InMemoryMunicipalityRepository : IMunicipalityRepository
    {
        public Task<IEnumerable<Municipality>> Get(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Municipality>> Get(Expression<Func<Municipality, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Municipality> Get(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(Municipality entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Municipality entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Update(Expression<Func<Municipality, bool>> filter, Municipality entity, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Expression<Func<Municipality, bool>> filter, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteManyAsync(IEnumerable<Municipality> collection, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}