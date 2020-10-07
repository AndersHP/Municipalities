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
    public class When_Getting_Municipalities
    {
        [Fact]
        public async void Existing_Municipality_Is_Returned()
        {
            //Arrange
            var repo = new InMemoryMunicipalityRepository(new List<Municipality>());
            await repo.Create(getTestMunicipality(), new CancellationToken());

            //Act
            var res = await repo.Get(
                m => m.GetName() == getTestMunicipality().GetName(),
                new CancellationToken());

            //Assert
            res.First().ShouldBeOfType<Municipality>();
        }

        [Fact]
        public async void Nonexisting_Finds_Nothing()
        {
            //Arrange
            var repo = new InMemoryMunicipalityRepository(new List<Municipality>());
            await repo.Create(getTestMunicipality(), new CancellationToken());

            //Act
            var res = await repo.Get(
                m => m.GetName() == "",
                new CancellationToken());

            //Assert
            res.FirstOrDefault().ShouldBe(null);
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