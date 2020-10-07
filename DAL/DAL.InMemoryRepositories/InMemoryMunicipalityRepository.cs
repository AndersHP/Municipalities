using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccessContracts;
using Core.Domain;

namespace DAL.InMemoryRepositories
{
    public class InMemoryMunicipalityRepository : IMunicipalityRepository
    {
        private List<Municipality> _municipalities;

        public InMemoryMunicipalityRepository(List<Municipality> municipalities)
        {
            _municipalities = municipalities;
        }

        public Task<IEnumerable<Municipality>> Get(CancellationToken cancellationToken) 
            => Task.FromResult<IEnumerable<Municipality>>(_municipalities);

        public Task<IEnumerable<Municipality>> Get(Expression<Func<Municipality, bool>> filter, CancellationToken cancellationToken)
        {
            var result = _municipalities.AsQueryable().Where(filter);
            return Task.FromResult<IEnumerable<Municipality>>(result);
        }

        public Task<Municipality> Get(int id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //TODO: Consider doing something to use name as ID instead
        public Task<int> Create(Municipality municipality, CancellationToken cancellationToken)
        {
            _municipalities.Add(municipality);
            return Task.FromResult(1);
        }

        public Task Update(Municipality municipality, CancellationToken cancellationToken)
        {
            var toUpdate = _municipalities
                .FirstOrDefault(m => m.GetName() == municipality.GetName());
            _municipalities.Remove(toUpdate);
            _municipalities.Add(municipality);

            return null;
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