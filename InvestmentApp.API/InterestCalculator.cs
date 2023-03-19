using InvestmentAppProd.Models;

namespace InvestmentApp.API
{
    public abstract class InterestCalculator
    {
        public InterestCalculator()
        {

        }

        public abstract double CalculateInterestValue(Investment investment);
    }
}
