using InvestmentApp.Core.Entities;
using System;

namespace InvestmentApp.Core.Calculators
{
    public class SimpleInterestCalculator : InterestCalculator
    {
        public SimpleInterestCalculator()
        {

        }

        public override double CalculateInterestValue(Investment investment)
        {
            double r;
            double t;
            double n;
            double simpleInterestFinalAmount;
            double monthsDiff;

            // Interest rate is divided by 100.
            r = investment.InterestRate / 100;

            // Time t is calculated to the nearest month.
            monthsDiff = 12 * (investment.StartDate.Year - DateTime.Now.Year) + investment.StartDate.Month - DateTime.Now.Month;
            monthsDiff = Math.Abs(monthsDiff);
            t = monthsDiff / 12;

            // SIMPLE INTEREST.
            simpleInterestFinalAmount = investment.PrincipalAmount * (1 + (r * t));

            return Math.Round(simpleInterestFinalAmount, 2);
        }
    }
}
