using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccessContracts;
using Core.Domain;

namespace Core.Usecases.Tests.Fakes
{
    public class FakeRepository : IMunicipalityRepository
    {
        private List<Municipality> _municipalities;

        public FakeRepository()
        {
            _municipalities = new List<Municipality>()
            {
                new Municipality("Copenhagen", new List<TaxPeriod>()
                {
                    new TaxPeriod(20, 
                        new DateTime(2016, 1, 1), 
                        new DateTime(2016, 12, 31) ),
                    new TaxPeriod(40, 
                        new DateTime(2016, 5, 1), 
                        new DateTime(2016, 5, 31) ),
                    new TaxPeriod(10, 
                        new DateTime(2016, 1, 1), 
                        new DateTime(2016, 1, 1) ),
                    new TaxPeriod(10, 
                        new DateTime(2016, 12, 25), 
                        new DateTime(2016, 12, 25) ),
                }),
                new Municipality("Aarhus", new List<TaxPeriod>()
                {
                    new TaxPeriod(20, 
                        new DateTime(2016, 1, 1), 
                        new DateTime(2016, 12, 31) ),
                    new TaxPeriod(40, 
                        new DateTime(2016, 6, 1), 
                        new DateTime(2016, 8, 31) ),
                    new TaxPeriod(10, 
                        new DateTime(2016, 12, 5), 
                        new DateTime(2016, 12, 5) ),
                }),
            };
        }
        
        public Task<IEnumerable<Municipality>> Get(CancellationToken cancellationToken) => throw new NotImplementedException();

        public Task<IEnumerable<Municipality>> Get(Expression<Func<Municipality, bool>> filter, CancellationToken cancellationToken)
        {
            var result = _municipalities.AsQueryable().Where(filter);
            return Task.FromResult<IEnumerable<Municipality>>(result);
        }

        public Task<Municipality> Get(int id, CancellationToken cancellationToken) => throw new NotImplementedException();

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