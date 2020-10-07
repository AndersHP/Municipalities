using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.DataAccessContracts;
using Core.Domain;

namespace Core.Usecases
{
    public class MunicipalityHandler : IMunicipalityHandler
    {
        private readonly IMunicipalityRepository _municipalityRepository;

        public MunicipalityHandler(IMunicipalityRepository municipalityRepository)
        {
            _municipalityRepository = municipalityRepository;
        }
        
        public async Task<TaxPeriod> GetTaxInMunicipalityForGivenDate(string municipalityName, DateTime date)
        {
            var municipality = await GetMunicipality(municipalityName);
            var periodsContainingDate = municipality.GetScheduledTaxPeriods()
                .Where(period => period.Start <= date && period.End >= date);
            var shortestPeriod = periodsContainingDate
                .OrderBy(period => period.End - period.Start)
                .FirstOrDefault();

            return shortestPeriod;
        }

        public async Task<Municipality> GetMunicipality(string name)
        {
            //TODO: fix naming
            var municipalities = await _municipalityRepository.Get(municipality => municipality.GetName() == name, new CancellationToken());
            var enumerable = municipalities.ToList();
            if (enumerable.Count() == 1)
            {
                return enumerable.ToList().First();
            }
            else
            {
                throw new Exception("There should not be two municipalities with the same name");
            }
        }
    }
}