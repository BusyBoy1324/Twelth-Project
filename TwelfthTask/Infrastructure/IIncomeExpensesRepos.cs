using TwelfthTask.Models;

namespace TwelfthTask.Controllers
{
    public interface IIncomeExpensesRepos
    {
        Task<IList<IncomeExpenses>> GetAllAsync();
        Task<IncomeExpenses> GetByIdAsync(int id);
        void Insert(IncomeExpenses incomeExpenses);
        void Update(IncomeExpenses incomeExpenses);
        void Delete(IncomeExpenses incomeExpenses);
        Task<IncomeExpenses> FindAsync(int id);
    }
}
