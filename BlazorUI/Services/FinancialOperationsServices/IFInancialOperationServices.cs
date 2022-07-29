using TwelfthTask.Models;

namespace BlazorUI.Services.FinancialOperationsServices
{
    public interface IFInancialOperationServices
    {
        List<FinancialOperation> FinancialOperations { get; set; }
        Task<List<FinancialOperation>> GetAllFinancialOperationsAsync();
        Task<FinancialOperation> GetSingleFinanceOperationAsync(int id);
        Task<FinancialOperation> UpdateFinancialOperationAsync(FinancialOperation request);
        Task<FinancialOperationDto> CreateFinancialOperationAsync(FinancialOperationDto incomeExpensesDto);
        Task<List<FinancialOperation>> DeleteFinancialOperationAsync(int id);
    }
}
