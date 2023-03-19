using InvestmentApp.Core.Entities;
using InvestmentApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentApp.Infrastructure.ApplicationData
{
    public static class InvestmentDBSeed
    {
        public static void Initialize(InvestmentDBContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            var newInvestments = new List<Investment>();

            newInvestments.Add(
                new Investment
                {
                    Name = "Investment 1",
                    StartDate = DateTime.Parse("2022-03-01"),
                    InterestType = InterestType.Simple,
                    InterestRate = 3.875,
                    PrincipalAmount = 10000
                });
            newInvestments.Add(
                new Investment
                {
                    Name = "Investment 2",
                    StartDate = DateTime.Parse("2022-04-01"),
                    InterestType = InterestType.Simple,
                    InterestRate = 4,
                    PrincipalAmount = 15000
                });
            newInvestments.Add(
                new Investment
                {
                    Name = "Investment 3",
                    StartDate = DateTime.Parse("2022-05-01"),
                    InterestType = InterestType.Compound,
                    InterestRate = 5,
                    PrincipalAmount = 20000
                });

            // calculate the investment value
            foreach(var investment in newInvestments)
            {
                investment.CalculateValue();
            }

            context.Investments.AddRange(newInvestments);
            context.SaveChanges();
        }
    }
}
