using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IGetReports
    {
        Task<DailyReport> GetDailyReportAsync(DateTime date);
        Task<LongTermReport> GetLongTermReportAsync(DateTime stat, DateTime end);
    }
}
