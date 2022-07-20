using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IIncomeExpensesTypeServices
    {
        Task<IList<IncomeExpenses>> GetAllAsync();
        Task<IncomeExpenses> GetByIdAsync(int id);
        void Insert(IncomeExpenses incomeExpenses);
        void Update(IncomeExpenses incomeExpenses);
        void Delete(IncomeExpenses incomeExpenses);
        Task<IncomeExpenses> FindAsync(int id);
        IncomeExpenses GetMappedModel(IncomeExpensesCreate incomeExpensesCreate);
        void Save();
    }
}
