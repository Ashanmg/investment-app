using InvestmentApp.Core.Entities;

namespace InvestmentApp.Core.Calculators
{
    public class UnknownInterestCalculator : InterestCalculator
    {
        public UnknownInterestCalculator()
        {

        }

        public override double CalculateInterestValue(Investment investment)
        {
            // if we have differnent interest types except defined one, return zero value.
            return 0;
        }
    }
}
