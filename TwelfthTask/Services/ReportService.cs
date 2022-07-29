
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class ReportService : IReportService
    {
        private readonly IFinancialOperationServices _finServices;
        private readonly IIncomeExpensesTypeServices _incomeExpenses;

        public ReportService(IFinancialOperationServices finServices, IIncomeExpensesTypeServices incomeExpenses)
        {
            _finServices = finServices;
            _incomeExpenses = incomeExpenses;
        }

        public async Task<DailyReport> GetDailyReportAsync(DateTime date)
        {
            List<FinancialOperation> financialOperations = await _finServices.GetAllByDateAsync(date);
            List<IncomeExpenses> incomeExpenses = await _incomeExpenses.GetAllAsync();
            int expenses = 0, income = 0;
            foreach (var operation in financialOperations)
            {
                var operationType = incomeExpenses.Where(i => i.Id == operation.IncomeExpensesTypeId).FirstOrDefault();
                if (!operationType.IsIncome)
                {
                    expenses += operation.Price;
                }

                else
                {
                    income += operation.Price;
                }
            }

            var dailyReport = new DailyReport(date, income, expenses, financialOperations);
            return dailyReport;
        }

        public async Task<LongTermReport> GetLongTermReportAsync(DateTime start, DateTime end)
        {
            List<FinancialOperation> financialOperations = await _finServices.GetAllByPeriodAsync(start, end);
            List<IncomeExpenses> incomeExpenses = await _incomeExpenses.GetAllAsync();
            int expenses = 0, income = 0;
            foreach (var operation in financialOperations)
            {
                var operationType = incomeExpenses.Where(i => i.Id == operation.IncomeExpensesTypeId).FirstOrDefault();
                if (!operationType.IsIncome)
                {
                    expenses += operation.Price;
                }

                else
                {
                    income += operation.Price;
                }
            }

            var longTermReport = new LongTermReport(start, end, income, expenses, financialOperations);
            return longTermReport;
        }
    }
}
