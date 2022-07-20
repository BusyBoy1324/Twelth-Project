using AutoMapper;
using TwelfthTask.Controllers;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class IncomeExpensesTypeServices : IIncomeExpensesTypeServices
    {
        private TwelfthProjectContext _context;

        public IncomeExpensesTypeServices(TwelfthProjectContext context)
        {
            _context = context;
        }

        public void Delete(IncomeExpenses incomeExpenses)
        {
            _context.IncomeExpenses.Remove(incomeExpenses);
        }

        public async Task<IncomeExpenses> FindAsync(int id)
        {
            return await _context.IncomeExpenses.FindAsync(id);
        }

        public async Task<IList<IncomeExpenses>> GetAllAsync()
        {
            return await _context.IncomeExpenses.ToListAsync();
        }

        public async Task<IncomeExpenses> GetByIdAsync(int id)
        {
            return await _context.IncomeExpenses.Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public IncomeExpenses GetMappedModel(IncomeExpensesCreate incomeExpensesCreate)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IncomeExpensesCreate, IncomeExpenses>());
            var mapper = config.CreateMapper();
            IncomeExpenses incomeExpenses = mapper.Map<IncomeExpenses>(incomeExpensesCreate);
            return incomeExpenses;
        }

        public void Insert(IncomeExpenses incomeExpenses)
        {
            _context.IncomeExpenses.Add(incomeExpenses);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(IncomeExpenses incomeExpenses)
        {
            _context.IncomeExpenses.Update(incomeExpenses);
        }
    }
}
