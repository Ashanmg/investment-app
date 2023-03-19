using InvestmentApp.Core.Entities;

namespace InvestmentApp.Core.Calculators
{
    public abstract class InterestCalculator
    {
        public InterestCalculator()
        {

        }

        public abstract double CalculateInterestValue(Investment investment);
    }
}
