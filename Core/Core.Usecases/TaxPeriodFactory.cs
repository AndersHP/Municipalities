using System;
using Core.Domain;

namespace Core.Usecases
{
    public class TaxPeriodFactory
    {
        public TaxPeriod CreateTaxPeriod(DateTime start, TaxTypes type, int taxPercentage)
        {
            DateTime end;

            return type switch
            {
                TaxTypes.Yearly => CreateYearlyPeriod(start, taxPercentage),
                TaxTypes.Monthly => CreateMontlyPeriod(start, taxPercentage),
                TaxTypes.Weekly => CreateWeeklyPeriod(start, taxPercentage),
                TaxTypes.Daily => CreateDailyPeriod(start, taxPercentage),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }

        private static TaxPeriod CreateDailyPeriod(DateTime start, int taxPercentage) 
            => new TaxPeriod(taxPercentage, start, start);

        //TODO: could make the starting day of the week a preference as it varies from country to country
        private static TaxPeriod CreateWeeklyPeriod(DateTime start, int taxPercentage)
        {
            var dayOfWeek = start.DayOfWeek;
            var lastDayOfWeek = start.AddDays((int) (7 - dayOfWeek));
            var firstDayOfWeek = lastDayOfWeek.Subtract(new TimeSpan(6, 0, 0, 0));
            
            return new TaxPeriod(taxPercentage, firstDayOfWeek, lastDayOfWeek);
        }

        private static TaxPeriod CreateYearlyPeriod(DateTime start, int taxPercentage)
        {
            var fixedStart = new DateTime(start.Year, 1, 1);
            var end = fixedStart.AddDays(IsLeapYear(fixedStart) ? 365 : 364);
            return new TaxPeriod(taxPercentage, fixedStart, end);
        }

        private static TaxPeriod CreateMontlyPeriod(DateTime start, int taxPercentage)
        {
            var fixedStart = new DateTime(start.Year, start.Month, 1);
            var lengthOfMonth = DateTime.DaysInMonth(fixedStart.Year, fixedStart.Month);
            var end = fixedStart.AddDays(lengthOfMonth - 1); 
            
            return new TaxPeriod(taxPercentage, fixedStart, end);
        }
        
        private static bool IsLeapYear(DateTime start) 
            => start.Year % 4 == 0;
            // && start.Year % 100 == 0 
            // && start.Year % 400 == 0;
    }
}