using TwelfthTask.Models;

namespace TwelfthTask.Infrastructure
{
    public interface IFinancialOperationRepos
    {
        Task<List<FinancialOperation>> GetAllAsync();
        Task<FinancialOperation> GetByIdAsync(int id);
        void Insert(FinancialOperation financialOperation);
        void Update(FinancialOperation financialOperation);
        void Delete(FinancialOperation financialOperation);
        Task<FinancialOperation> FindAsync(int id);
    }
}
