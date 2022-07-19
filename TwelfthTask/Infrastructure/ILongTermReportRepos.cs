using TwelfthTask.Models;

namespace TwelfthTask.Infrastructure
{
    public interface ILongTermReportRepos
    {
        (int income, int expenses, List<FinancialOperation> financialOperations) GetInformationAboutDatePeriod
            (List<FinancialOperation> allFinancialOperations, DateTime startDate, DateTime endDate);
    }
}
