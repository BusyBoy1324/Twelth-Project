using AutoMapper;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class FinancialOperationServices : IFinancialOperationServices
    {
        private readonly IMapper _mapper;
        private TwelfthProjectContext _context;

        public FinancialOperationServices(TwelfthProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task Delete(int id)
        {
            var financialOperation = await FindAsync(id);
            _context.FinancialOperations.Remove(financialOperation);
            await Save();
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

        public FinancialOperation GetMappedModel(FinancialOperationDto financialOperationCreate)
        {
            FinancialOperation financialOperation = _mapper.Map<FinancialOperation>(financialOperationCreate);
            return financialOperation;
        }

        public async Task<FinancialOperation> InsertAsync(FinancialOperationDto financialOperationCreate)
        {
            var incomeExpenses = await _context.IncomeExpenses.Where(n => n.Name == financialOperationCreate.IncomeExpensesName).FirstOrDefaultAsync();
            if (incomeExpenses != null)
            {
                financialOperationCreate.IncomeExpensesTypeId = incomeExpenses.Id;
            }
            var financialOperation = GetMappedModel(financialOperationCreate);
            _context.FinancialOperations.Add(financialOperation);
            await Save();
            return financialOperation;
        }

        public async Task UpdateAsync(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Update(financialOperation);
            await Save();
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<FinancialOperation>> GetAllByDateAsync(DateTime date)
        {
            var financialOperations = await _context.FinancialOperations.Where(d => d.Date == date).ToListAsync();
            return financialOperations;
        }

        public async Task<List<FinancialOperation>> GetAllByPeriodAsync(DateTime startDate, DateTime endDate)
        {
            var financialOperations = await _context.FinancialOperations.Where(d => d.Date < endDate || d.Date > startDate).ToListAsync();
            return financialOperations;
        }
    }
}
