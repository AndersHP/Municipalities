using System;
using Core.Domain;

namespace Core.Usecases
{
    public interface IMunicipalityHandler
    {
        TaxPeriod GetTaxInMunicipalityForGivenDate(string municipalityName, DateTime date);
        Municipality GetMunicipality(string name);
    }
}