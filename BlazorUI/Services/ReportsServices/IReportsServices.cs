using TwelfthTask.Models;
using TwelfthTask.Services;

namespace BlazorUI.Services.ReportsServices
{
    public interface IReportsServices
    {
        Task<DailyReport> GetDailyReportByDate(DateTime date);
        Task<LongTermReport> GetLongTermReportByDate(DateTime startDate, DateTime endDate);
    }
}
