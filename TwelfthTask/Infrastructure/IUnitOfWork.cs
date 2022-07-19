using TwelfthTask.Controllers;

namespace TwelfthTask.Infrastructure
{
    public interface IUnitOfWork
    {
        IFinancialOperationRepos FinancialOperation { get; }
        IIncomeExpensesRepos IncomeExpenses { get; }
        Task Save();
    }
}
