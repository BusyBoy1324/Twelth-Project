using TwelfthTask.Models;

namespace BlazorUI.Services.FinancialOperationsServices
{
    public class FinancialOperationServices : IFInancialOperationServices
    {
        private readonly HttpClient _httpClient;

        public FinancialOperationServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<FinancialOperation> FinancialOperations { get; set; } = new();

        public async Task CreateFinancialOperationAsync(FinancialOperationDto financialOperationDto)
        {
            await _httpClient.PostAsJsonAsync<FinancialOperationDto>("/api/FinancialOperation/CreateFinancialOperation", financialOperationDto);
        }

        public async Task DeleteFinancialOperationAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/FinancialOperation/DeleteFinancialOperation?id={id}");
        }

        public async Task GetAllFinancialOperationsAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<FinancialOperation>>("/api/FinancialOperation/AllFinancialOperations");
            if (result != null)
            {
                FinancialOperations = result;
            }
        }

        public async Task<FinancialOperation> GetSingleFinanceOperationAsync(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<FinancialOperation>($"api/FinancialOperation/{id}");
            return result;
        }

        public async Task UpdateFinancialOperationAsync(FinancialOperation request)
        {
            await _httpClient.PutAsJsonAsync<FinancialOperation>("/api/FinancialOperation/UpdateFinancialOperation", request);
        }
    }
}
