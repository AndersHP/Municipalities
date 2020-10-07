using System;
using Core.Domain;
using Shouldly;
using Xunit;

namespace Core.Usecases.Tests
{
    public class When_Creating_TaxPeriod
    {
        [Fact]
        public void Daily_Should_End_Same_Day()
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = new DateTime(2019, 1, 2);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Daily, 1);

            //Assert
            res.End.ShouldBe(start);
        }
        
        [Fact]
        public void Weekly_Should_Start_On_A_Monday()
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = new DateTime(2020, 1, 2);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Weekly, 1);

            //Assert
            res.Start.ShouldBe(new DateTime(2019, 12, 30));
        }
        
        [Fact]
        public void Weekly_Should_End_On_A_Sunday()
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = new DateTime(2020, 1, 2);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Weekly, 1);

            //Assert
            res.End.ShouldBe(new DateTime(2020, 1, 5));
        }
        
        [Fact]
        public void Monthly_Should_Start_On_The_First()
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = new DateTime(2020, 1, 2);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Monthly, 1);

            //Assert
            res.Start.ShouldBe(new DateTime(2020, 1, 1));
        }
        
        [Theory]
        [InlineData("2019/02/02", "2019/02/28")] //non leap year february
        [InlineData("2000/02/01", "2000/02/29")] //leap year february
        [InlineData("2000/01/01", "2000/01/31")] //January
        [InlineData("2000/03/01", "2000/03/31")] //March
        [InlineData("2000/04/01", "2000/04/30")] //April
        [InlineData("2000/05/01", "2000/05/31")] //May
        [InlineData("2000/06/01", "2000/06/30")] //June
        [InlineData("2000/07/01", "2000/07/31")] //July
        [InlineData("2000/08/01", "2000/08/31")] //August
        [InlineData("2000/09/01", "2000/09/30")] //September
        [InlineData("2000/10/01", "2000/10/31")] //October
        [InlineData("2000/11/01", "2000/11/30")] //November
        [InlineData("2000/12/01", "2000/12/31")] //December
        public void Monthly_Should_End_On_A_The_Last(string date, string expectedEnd)
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = DateTime.Parse(date);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Monthly, 1);

            //Assert
            res.End.ShouldBe(DateTime.Parse(expectedEnd));
        }
        
        [Fact]
        public void Yearly_Should_Start_On_New_Years_Day()
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = new DateTime(2020, 1, 2);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Yearly, 1);

            //Assert
            res.Start.ShouldBe(new DateTime(2020, 1, 1));
        }
        
        [Theory]
        [InlineData("2019/01/02", "2019/12/31")] //non leap year
        [InlineData("2000/01/01", "2000/12/31")] //leap year
        public void Yearly_Should_End_On_New_Years_Eve(string date, string expectedEnd)
        {
            //Arrange
            var factory = new TaxPeriodFactory();
            var start = DateTime.Parse(date);
            
            //Act
            var res = factory.CreateTaxPeriod(start, TaxTypes.Yearly, 1);

            //Assert
            res.End.ShouldBe(DateTime.Parse(expectedEnd));
        }
    }
}