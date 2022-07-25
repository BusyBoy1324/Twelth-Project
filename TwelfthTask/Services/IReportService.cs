using TwelfthTask.Models;

namespace TwelfthTask.Services
{
    public interface IReportService
    {
        Task<DailyReport> GetDailyReportAsync(DateTime date);
        Task<LongTermReport> GetLongTermReportAsync(DateTime stat, DateTime end);
    }
}
