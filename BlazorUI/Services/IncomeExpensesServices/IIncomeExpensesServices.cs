using TwelfthTask.Models;

namespace BlazorUI.Services.IncomeExpensesService
{
    public interface IIncomeExpensesServices
    {
        List<IncomeExpenses> IncomeExpenses { get; set; }
        Task GetAllIncomeExpensesAsync();
        Task<IncomeExpenses> GetSingleIncomeExpensesAsync(int id);
        Task UpdateIncomeExpensesAsync(IncomeExpenses request);
        Task CreateIncomeExpensesAsync(IncomeExpensesDto incomeExpensesDto);
        Task DeleteIncomeExpensesAsync(int id);
    }
}
