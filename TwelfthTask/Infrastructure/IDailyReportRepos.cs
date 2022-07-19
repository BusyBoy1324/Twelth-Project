using TwelfthTask.Models;

namespace TwelfthTask.Infrastructure
{
    public interface IDailyReportRepos
    {
        (int income, int expenses, List<FinancialOperation> financialOperations) GetInformationAboutDate(List<FinancialOperation> allFinancialOperations, DateTime date);
    }
}
