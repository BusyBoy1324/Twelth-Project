using TwelfthTask.Models;

namespace BlazorUI.Services.IncomeExpensesService
{
    public interface IIncomeExpensesServices
    {
        List<IncomeExpenses> IncomeExpenses { get; set; }
        Task<List<IncomeExpenses>> GetAllIncomeExpensesAsync();
        Task<IncomeExpenses> GetSingleIncomeExpensesAsync(int id);
        Task<IncomeExpenses> UpdateIncomeExpensesAsync(IncomeExpenses request);
        Task<IncomeExpensesDto> CreateIncomeExpensesAsync(IncomeExpensesDto incomeExpensesDto);
        Task<List<IncomeExpenses>> DeleteIncomeExpensesAsync(int id);
    }
}
