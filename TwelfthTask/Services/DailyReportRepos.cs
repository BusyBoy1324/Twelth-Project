using TwelfthTask.Infrastructure;
using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public class DailyReportRepos : IDailyReportRepos
    {
        public (int income, int expenses, List<FinancialOperation> financialOperations) GetInformationAboutDate(List<FinancialOperation> allFinancialOperations, DateTime date)
        {
            int income = 0, expenses = 0;
            List<FinancialOperation> financialOperations = new List<FinancialOperation>();
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
            return (income, expenses, financialOperations);
        }
    }
}
