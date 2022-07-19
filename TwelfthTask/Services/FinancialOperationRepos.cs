using TwelfthTask.Infrastructure;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class FinancialOperationRepos : IFinancialOperationRepos
    {
        private TwelfthProjectContext _context;

        public FinancialOperationRepos(TwelfthProjectContext context)
        {
            _context = context;
        }

        public void Delete(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Remove(financialOperation);
        }

        public async Task<FinancialOperation> FindAsync(int id)
        {
            return await _context.FinancialOperations.FindAsync(id);
        }

        public async Task<List<FinancialOperation>> GetAllAsync()
        {
            return await _context.FinancialOperations.ToListAsync();
        }

        public async Task<FinancialOperation> GetByIdAsync(int id)
        {
            return await _context.FinancialOperations.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public void Insert(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Add(financialOperation);
        }

        public void Update(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Update(financialOperation);
        }
    }
}
