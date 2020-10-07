using System;

namespace Core.Domain
{
    public class TaxPeriod
    {
        public int TaxPercentage { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public TaxPeriod(int taxPercentage, DateTime start, DateTime end)
        {
            TaxPercentage = taxPercentage;
            Start = start;
            End = end;
        }
    }
}