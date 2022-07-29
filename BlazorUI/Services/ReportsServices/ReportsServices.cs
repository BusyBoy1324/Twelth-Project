using TwelfthTask.Models;
using TwelfthTask.Services;

namespace BlazorUI.Services.ReportsServices
{
    public class ReportsServices : IReportsServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public ReportsServices(IHttpClientFactory _clientFactory)
        {
            _clientFactory = _clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public async Task<DailyReport> GetDailyReportByDate(DateTime date)
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        $"api/ReportsContoller/{date.ToString("yyyy-MM-dd")}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(DailyReport);
                    }

                    return await response.Content.ReadFromJsonAsync<DailyReport>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<LongTermReport> GetLongTermReportByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        $"api/ReportsContoller/{startDate.ToString("yyyy-MM-dd")}, {endDate.ToString("yyyy-MM-dd")}");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(LongTermReport);
                    }

                    return await response.Content.ReadFromJsonAsync<LongTermReport>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
