using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IFinancialOperationServices
    {
        Task<List<FinancialOperation>> GetAllAsync();
        Task<FinancialOperation> GetByIdAsync(int id);
        Task<FinancialOperation> InsertAsync(FinancialOperationDto financialOperationCreate);
        Task UpdateAsync(FinancialOperation financialOperation);
        Task Delete(int id);
        Task<FinancialOperation> FindAsync(int id);
        Task<List<FinancialOperation>> GetAllByDateAsync(DateTime date);
        Task<List<FinancialOperation>> GetAllByPeriodAsync(DateTime staDate, DateTime endDate);
    }
}
