using TwelfthTask.Infrastructure;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class LongTermReportRepos : ILongTermReportRepos
    {
        public (int income, int expenses, List<FinancialOperation> financialOperations) GetInformationAboutDatePeriod
            (List<FinancialOperation> allFinancialOperations, DateTime startDate, DateTime endDate)
        {
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
            int income = 0, expenses = 0;
            foreach (var op in allFinancialOperations)
            {
                if (op.Date.Date >= startDate && op.Date.Date <= endDate)
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
            return (income, expenses, financialOperations);
        }
    }
}
