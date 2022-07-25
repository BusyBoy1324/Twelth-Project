using AutoMapper;
using TwelfthTask.Controllers;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class IncomeExpensesTypeServices : IIncomeExpensesTypeServices
    {
        private readonly IMapper _mapper;
        private TwelfthProjectContext _context;

        public IncomeExpensesTypeServices(TwelfthProjectContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task DeleteAsync(int id)
        {
            var incomeExpenses = await FindAsync(id);
            _context.IncomeExpenses.Remove(incomeExpenses);
            await Save();
        }

        public async Task<IncomeExpenses> FindAsync(int id)
        {
            return await _context.IncomeExpenses.FindAsync(id);
        }

        public async Task<List<IncomeExpenses>> GetAllAsync()
        {
            return await _context.IncomeExpenses.ToListAsync();
        }

        public async Task<IncomeExpenses> GetByIdAsync(int id)
        {
            return await _context.IncomeExpenses.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public IncomeExpenses GetMappedModel(IncomeExpensesDto incomeExpensesCreate)
        {
            IncomeExpenses incomeExpenses = _mapper.Map<IncomeExpenses>(incomeExpensesCreate);
            return incomeExpenses;
        }

        public async Task<IncomeExpenses> InsertAsync(IncomeExpensesDto incomeExpensesCreate)
        {
            var incomeExpenses = GetMappedModel(incomeExpensesCreate);
            _context.IncomeExpenses.Add(incomeExpenses);
            await Save();
            return incomeExpenses;
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(IncomeExpenses incomeExpenses)
        {
            _context.IncomeExpenses.Update(incomeExpenses);
            await Save();
        }
    }
}
