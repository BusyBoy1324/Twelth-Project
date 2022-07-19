using TwelfthTask.Controllers;
using TwelfthTask.Infrastructure;

namespace TwelfthTask.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private TwelfthProjectContext _context;
        private IFinancialOperationRepos _financialOperationRepos;
        private IIncomeExpensesRepos _incomeExpenses;

        public UnitOfWork(TwelfthProjectContext context)
        {
            _context = context;
        }

        public IIncomeExpensesRepos IncomeExpenses
        {
            get
            {
                return _incomeExpenses = _incomeExpenses ?? new IncomeExpensesRepos(_context);
            }
        }

        public IFinancialOperationRepos FinancialOperation
        {
            get
            {
                return _financialOperationRepos = _financialOperationRepos ?? new FinancialOperationRepos(_context);
            }
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
