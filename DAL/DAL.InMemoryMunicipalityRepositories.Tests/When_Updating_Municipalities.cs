using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Core.Domain;
using DAL.InMemoryRepositories;
using Shouldly;
using Xunit;

namespace DAL.InMemoryMunicipalityRepositories.Tests
{
    public class When_Updating_Municipalities
    {
        [Fact]
        public async void TaxPeriod_Is_Added()
        {
            //Arrange
            var municipality = getTestMunicipality();
            var repo = new InMemoryMunicipalityRepository(new List<Municipality>());
            await repo.Create(getTestMunicipality(), new CancellationToken());
            
            municipality.AddTaxPeriod(new TaxPeriod(
                50,
                new DateTime(2022, 1, 1),
                new DateTime(2022, 1, 31)));
            
            //Act
            repo.Update(municipality, new CancellationToken());
            var res = await repo.Get(
                m => m.GetName() == municipality.GetName(),
                new CancellationToken());

            //Assert
            res.First().GetScheduledTaxPeriods().ToList().Count.ShouldBe(2);
        }

        private static Municipality getTestMunicipality()
        {
            return new Municipality("Copenhagen", new List<TaxPeriod>()
            {
                new TaxPeriod(50,
                    new DateTime(2020, 1, 1),
                    new DateTime(2020, 1, 31))
            });
        }
    }
}