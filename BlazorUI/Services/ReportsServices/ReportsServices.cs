using TwelfthTask.Models;
using TwelfthTask.Services;

namespace BlazorUI.Services.ReportsServices
{
    public class ReportsServices : IReportsServices
    {
        private readonly HttpClient _httpClient;

        public ReportsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<DailyReport> GetDailyReportByDate(DateTime date)
        {
             Console.WriteLine(_httpClient.BaseAddress + $"api/ReportsContoller/{date.ToString("yyyy-MM-dd")}");
             DailyReport dailyReport = await _httpClient.GetFromJsonAsync<DailyReport>($"api/ReportsContoller/{date.ToString("yyyy-MM-dd")}");
             return dailyReport;
        }

        public async Task<LongTermReport> GetLongTermReportByDate(DateTime startDate, DateTime endDate)
        {
            LongTermReport longTermReport =
                await _httpClient.GetFromJsonAsync<LongTermReport>($"api/ReportsContoller/{startDate.ToString("yyyy-MM-dd")}, {endDate.ToString("yyyy-MM-dd")}");
            return longTermReport;
        }
    }
}
