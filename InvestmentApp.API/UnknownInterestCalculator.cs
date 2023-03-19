using InvestmentAppProd.Models;

namespace InvestmentApp.API
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
