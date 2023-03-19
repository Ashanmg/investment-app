using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using InvestmentApp.API;

namespace InvestmentAppProd.Models
{
	public class Investment
	{
		[Required]
		[Key]
		public string Name { get; set; }

		public DateTime StartDate { get; set; }

		public InterestType InterestType { get; set; }

		public double InterestRate { get; set; }

		public double PrincipalAmount { get; set; }

		public double CurrentValue { get; set; } = 0;

		public Investment()
		{
		}

		public Investment(string name, DateTime startDate, string interestType, double rate, double principal)
		{
			Name = name;
			StartDate = startDate;
			InterestType = Enum.Parse<InterestType>(interestType);
			InterestRate = rate;
			PrincipalAmount = principal;
		}

		public void CalculateValue()
		{
			var factory = new InterestCalculatorFactory();

			var calculator = factory.Create(this);
			this.CurrentValue = calculator.CalculateInterestValue(this);

        }
	}
}
