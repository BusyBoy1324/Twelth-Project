using Microsoft.EntityFrameworkCore;
using TwelfthTask.Models;
using TwelfthTask.Services;

namespace TwelfthTask.Data
{
    public class TwelfthProjectContext : DbContext
    {
        public TwelfthProjectContext(DbContextOptions<TwelfthProjectContext> options) 
            : base(options)
        {
        }

        public DbSet<FinancialOperation> FinancialOperations { get; set; }
        public DbSet<IncomeExpenses> IncomeExpenses { get; set; }
    }
}
