using InvestmentApp.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentApp.Infrastructure.ApplicationData
{
    public class InvestmentDBContext : DbContext
    {
        public DbSet<Investment> Investments { get; set; }

        public InvestmentDBContext(DbContextOptions<InvestmentDBContext> options) : base(options)
        {
        }

    }
}
