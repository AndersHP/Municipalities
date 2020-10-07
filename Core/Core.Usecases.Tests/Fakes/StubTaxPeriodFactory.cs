using System;
using Core.Domain;

namespace Core.Usecases.Tests.Fakes
{
    public class StubTaxPeriodFactory : ITaxPeriodFactory
    {
        public TaxPeriod CreateTaxPeriod(DateTime start, TaxTypes type, int percentage)
        {
            throw new NotImplementedException();
        }
    }
}