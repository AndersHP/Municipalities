using System;
using System.Threading.Tasks;
using Core.Domain;

namespace Core.Usecases
{
    public interface IMunicipalityHandler
    {
        Task<TaxPeriod> GetTaxInMunicipalityForGivenDate(string municipalityName, DateTime date);
        Task<Municipality> GetMunicipality(string name);
        void AddScheduledTax(Municipality municipality, DateTime start, TaxTypes type, int taxPercentage);
    }
}