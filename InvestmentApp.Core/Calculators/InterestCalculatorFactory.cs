using InvestmentApp.Core.Entities;
using InvestmentApp.Core.Enums;
using System;

namespace InvestmentApp.Core.Calculators
{
    public class InterestCalculatorFactory
    {
        public InterestCalculator Create(Investment investment)
        {
            try
            {
                return (InterestCalculator)Activator.CreateInstance(
                    Type.GetType($"InvestmentApp.Core.Calculators.{Enum.GetName(typeof(InterestType), investment.InterestType)}InterestCalculator"));
            }
            catch (Exception ex)
            {
                return new UnknownInterestCalculator();
            }
        }
    }
}
