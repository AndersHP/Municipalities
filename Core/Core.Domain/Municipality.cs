using System.Collections.Generic;

namespace Core.Domain
{
    public class Municipality
    {
        private string _name;
        private List<TaxPeriod> _scheduledTaxPeriods;

        public Municipality(string name, List<TaxPeriod> scheduledTaxPeriods)
        {
            _name = name;
            _scheduledTaxPeriods = scheduledTaxPeriods;
        }

        public void AddTaxPeriod(TaxPeriod taxPeriod) 
            => _scheduledTaxPeriods.Add(taxPeriod);

        public IEnumerable<TaxPeriod> GetScheduledTaxPeriods() 
            => _scheduledTaxPeriods;

        public string GetName() => _name;
    }
}