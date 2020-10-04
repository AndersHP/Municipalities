using System;

namespace Core.Domain
{
    public class TaxPeriod
    {
        public int TaxPercentage { get; set; }
        public TimeSpan Period { get; set; }

        public TaxPeriod(int taxPercentage, TimeSpan period)
        {
            TaxPercentage = taxPercentage;
            Period = period;
        }
    }
}