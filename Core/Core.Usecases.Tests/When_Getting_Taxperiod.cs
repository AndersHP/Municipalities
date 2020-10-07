using System;
using Core.Usecases.Tests.Fakes;
using Shouldly;
using Xunit;

namespace Core.Usecases.Tests
{
    public class When_Getting_Taxperiod
    {
        //Name, date, expectedTaxPercentage
        [Theory]
        [InlineData("Copenhagen", "2016/01/01", 10)]
        [InlineData("Copenhagen", "2016/01/02", 20)]
        [InlineData("Copenhagen", "2016/05/01", 40)]
        [InlineData("Copenhagen", "2016/05/31", 40)]
        [InlineData("Copenhagen", "2016/07/10", 20)]
        public async void Should_Return_Shortest_Period_That_Spans_Given_Date(string name, string datestring, int expectedTax)
        {
            //Arrange
            var repo = new FakeRepository();
            var factory = new StubTaxPeriodFactory();
            var handler = new MunicipalityHandler(repo, factory);
            var date = DateTime.Parse(datestring);
            
            //Act
            var res = await handler.GetTaxInMunicipalityForGivenDate(name, date);

            //Assert
            res.TaxPercentage.ShouldBe(expectedTax);
        }
    }
}