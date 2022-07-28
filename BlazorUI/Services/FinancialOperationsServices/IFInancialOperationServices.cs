using TwelfthTask.Models;

namespace BlazorUI.Services.FinancialOperationsServices
{
    public interface IFInancialOperationServices
    {
        List<FinancialOperation> FinancialOperations { get; set; }
        Task GetAllFinancialOperationsAsync();
        Task<FinancialOperation> GetSingleFinanceOperationAsync(int id);
        Task UpdateFinancialOperationAsync(FinancialOperation request);
        Task CreateFinancialOperationAsync(FinancialOperationDto incomeExpensesDto);
        Task DeleteFinancialOperationAsync(int id);
    }
}
