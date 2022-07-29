using System.Net;
using TwelfthTask.Models;

namespace BlazorUI.Services.FinancialOperationsServices
{
    public class FinancialOperationServices : IFInancialOperationServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public FinancialOperationServices(IHttpClientFactory _clientFactory)
        {
            _clientFactory = _clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public List<FinancialOperation> FinancialOperations { get; set; } = new();

        public async Task<FinancialOperationDto> CreateFinancialOperationAsync(FinancialOperationDto financialOperationDto)
        {
            try
            {
                var response =
                    await _httpClient.PostAsJsonAsync<FinancialOperationDto>(
                        "/api/FinancialOperation/CreateFinancialOperation", financialOperationDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FinancialOperationDto);
                    }

                    return await response.Content.ReadFromJsonAsync<FinancialOperationDto>();
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

        public async Task<List<FinancialOperation>> DeleteFinancialOperationAsync(int id)
        {
            try
            {
                var response =
                    await _httpClient.DeleteAsync($"api/FinancialOperation/DeleteFinancialOperation?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<FinancialOperation>>();
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

        public async Task<List<FinancialOperation>> GetAllFinancialOperationsAsync()
        {
            try
            {
                var response =
                    await _httpClient.GetAsync(
                        "/api/FinancialOperation/AllFinancialOperations");
                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<FinancialOperation>();
                    }

                    FinancialOperations = await response.Content.ReadFromJsonAsync<List<FinancialOperation>>();
                    return FinancialOperations;
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

        public async Task<FinancialOperation> GetSingleFinanceOperationAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync(
                    $"api/FinancialOperation/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FinancialOperation);
                    }

                    return await response.Content.ReadFromJsonAsync<FinancialOperation>();
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

        public async Task<FinancialOperation> UpdateFinancialOperationAsync(FinancialOperation request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<FinancialOperation>("/api/FinancialOperation/UpdateFinancialOperation",
                    request);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(FinancialOperation);
                    }

                    return await response.Content.ReadFromJsonAsync<FinancialOperation>();
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
