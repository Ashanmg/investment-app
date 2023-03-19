using InvestmentApp.Core.Entities;
using InvestmentApp.Core.Enums;

namespace InvestmentApp.Core.Calculators
{
    public class InterestCalculatorFactory
    {
        public InterestCalculator Create(Investment investment)
        {
            switch (investment.InterestType)
            {
                case InterestType.Simple:
                    return new SimpleInterestCalculator();

                case InterestType.Compound:
                    return new CompoundInterestCalculator();

                default:
                    return new UnknownInterestCalculator();
            }
        }
    }
}
