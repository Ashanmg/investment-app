using InvestmentApp.Core.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentApp.API.Models
{
    public class InvestmentRequest
    {
        [Required]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public string InterestType { get; set; }

        public double InterestRate { get; set; }

        public double PrincipalAmount { get; set; }
    }
}
