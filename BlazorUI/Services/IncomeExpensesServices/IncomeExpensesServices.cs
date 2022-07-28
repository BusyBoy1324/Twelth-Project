using TwelfthTask.Models;

namespace BlazorUI.Services.IncomeExpensesService
{
    public class IncomeExpensesServices : IIncomeExpensesServices
    {
        private readonly HttpClient _httpClient;

        public IncomeExpensesServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<IncomeExpenses> IncomeExpenses { get; set; } = new();

        public async Task GetAllIncomeExpensesAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<IncomeExpenses>>("/api/IncomeExpenses/AllIncomeExpenses");
            if (result != null)
            {
                IncomeExpenses = result;
            }
        }

        public async Task UpdateIncomeExpensesAsync(IncomeExpenses request)
        {
            await _httpClient.PutAsJsonAsync<TwelfthTask.Models.IncomeExpenses>("/api/IncomeExpenses/UpdateIncomeExpenses", request);
        }

        public async Task CreateIncomeExpensesAsync(IncomeExpensesDto incomeExpensesDto)
        {
            await _httpClient.PostAsJsonAsync<IncomeExpensesDto>("/api/IncomeExpenses/CreateIncomeExpenses", incomeExpensesDto);
        }

        public async Task DeleteIncomeExpensesAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/IncomeExpenses/DeleteIncomeExpenses?id={id}");
        }

        public async Task<IncomeExpenses> GetSingleIncomeExpensesAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<IncomeExpenses>($"api/IncomeExpenses/{id}");
            return result;
        }
    }
}
