using AutoMapper;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class FinancialOperationServices : IFinancialOperationServices
    {
        private TwelfthProjectContext _context;

        public FinancialOperationServices(TwelfthProjectContext context)
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

        public FinancialOperation GetMappedModel(FinancialOperationCreate financialOperationCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<FinancialOperationCreate, FinancialOperation>());
            var mapper = config.CreateMapper();
            FinancialOperation financialOperation = mapper.Map<FinancialOperation>(financialOperationCreate);
            return financialOperation;
        }

        public void Insert(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Add(financialOperation);
        }

        public void Update(FinancialOperation financialOperation)
        {
            _context.FinancialOperations.Update(financialOperation);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
