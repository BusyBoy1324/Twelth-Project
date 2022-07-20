using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class GetReports : IGetReports
    {
        private readonly IFinancialOperationServices _finServices;

        public GetReports(IFinancialOperationServices finServices)
        {
            _finServices = finServices;
        }

        public async Task<DailyReport> GetDailyReportAsync(DateTime date)
        {
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
            int expenses = 0, income = 0;
            var allFinancialOperations = await _finServices.GetAllAsync();
            foreach (var operation in allFinancialOperations)
            {
                if (operation.Date.Date == date)
                {
                    financialOperations.Add(operation);
                    if (operation.Price < 0)
                    {
                        expenses += operation.Price;
                    }

                    if (operation.Price > 0)
                    {
                        income += operation.Price;
                    }
                }
            }
            var dailyReport = new DailyReport(date, income, expenses, financialOperations);
            return dailyReport;
        }

        public async Task<LongTermReport> GetLongTermReportAsync(DateTime start, DateTime end)
        {
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
            int expenses = 0, income = 0;
            var allFinancialOperations = await _finServices.GetAllAsync();
            foreach (var op in allFinancialOperations)
            {
                if (op.Date.Date >= start && op.Date.Date <= end)
                {
                    financialOperations.Add(op);
                    if (op.Price < 0)
                    {
                        expenses += op.Price;
                    }

                    if (op.Price > 0)
                    {
                        income += op.Price;
                    }
                }
            }
            var longTermReport = new LongTermReport(start, end, income, expenses, financialOperations);
            return longTermReport;
        }
    }
}
