using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IIncomeExpensesTypeServices
    {
        Task<List<IncomeExpenses>> GetAllAsync();
        Task<IncomeExpenses> GetByIdAsync(int id);
        Task<IncomeExpenses> InsertAsync(IncomeExpensesDto incomeExpensesCreate);
        Task UpdateAsync(IncomeExpenses incomeExpenses);
        Task DeleteAsync(int id);
        Task<IncomeExpenses> FindAsync(int id);
    }
}
