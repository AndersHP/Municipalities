using System;
using Core.Usecases.Tests.Fakes;
using Shouldly;
using Xunit;

namespace Core.Usecases.Tests
{
    public class When_Getting_Taxperiod
    {
        [Fact]
        public async void Should_Return_Shortest_Period_That_Spans_Given_Date()
        {
            //Arrange
            var repo = new FakeRepository();
            var handler = new MunicipalityHandler(repo);
            var name = "Copenhagen";
            var date = new DateTime(2016, 1, 1);
            
            //Act
            var res = await handler.GetTaxInMunicipalityForGivenDate(name, date);

            //Assert
            res.TaxPercentage.ShouldBe(10);
        }
    }
}