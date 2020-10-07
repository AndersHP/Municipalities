using System;
using Core.Domain;

namespace Core.Usecases
{
    public interface ITaxPeriodFactory
    {
        TaxPeriod CreateTaxPeriod(DateTime start, TaxTypes type, int percentage);
    }
}