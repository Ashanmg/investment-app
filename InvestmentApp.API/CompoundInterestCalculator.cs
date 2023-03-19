using InvestmentAppProd.Models;
using System;

namespace InvestmentApp.API
{
    public class CompoundInterestCalculator : InterestCalculator
    {
        public CompoundInterestCalculator()
        {

        }

        public override double CalculateInterestValue(Investment investment)
        {
            double r;
            double t;
            double n;
            double compoundInterestFinalAmount;
            double monthsDiff;

            // Interest rate is divided by 100.
            r = investment.InterestRate / 100;

            // Time t is calculated to the nearest month.
            monthsDiff = 12 * (investment.StartDate.Year - DateTime.Now.Year) + investment.StartDate.Month - DateTime.Now.Month;
            monthsDiff = Math.Abs(monthsDiff);
            t = monthsDiff / 12;

            // COMPOUND INTEREST.
            // Compounding period is set to monthly (i.e. n = 12).
            n = 12;
            compoundInterestFinalAmount = investment.PrincipalAmount * Math.Pow((1 + (r / n)), (n * t));

            return Math.Round(compoundInterestFinalAmount, 2);
        }
    }
}
