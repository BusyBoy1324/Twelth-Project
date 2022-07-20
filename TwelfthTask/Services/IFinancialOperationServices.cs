using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IFinancialOperationServices
    {
        Task<List<FinancialOperation>> GetAllAsync();
        Task<FinancialOperation> GetByIdAsync(int id);
        void Insert(FinancialOperation financialOperation);
        void Update(FinancialOperation financialOperation);
        void Delete(FinancialOperation financialOperation);
        Task<FinancialOperation> FindAsync(int id);
        FinancialOperation GetMappedModel(FinancialOperationCreate financialOperationCreate);
        void Save();
    }
}
