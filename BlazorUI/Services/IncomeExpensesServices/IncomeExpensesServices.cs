using TwelfthTask.Models;

namespace BlazorUI.Services.IncomeExpensesService
{
    public class IncomeExpensesServices : IIncomeExpensesServices
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient _httpClient;

        public IncomeExpensesServices(IHttpClientFactory _clientFactory)
        {
            _clientFactory = _clientFactory;
            _httpClient = _clientFactory.CreateClient("client");
        }

        public List<IncomeExpenses> IncomeExpenses { get; set; } = new();

        public async Task<List<IncomeExpenses>> GetAllIncomeExpensesAsync()
        {
            try
            {
                var response =
                    await _httpClient.GetAsync("/api/IncomeExpenses/AllIncomeExpenses");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return new List<IncomeExpenses>();
                    }

                    IncomeExpenses = await response.Content.ReadFromJsonAsync<List<IncomeExpenses>>();
                    return IncomeExpenses;
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

        public async Task<IncomeExpenses> UpdateIncomeExpensesAsync(IncomeExpenses request)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync<TwelfthTask.Models.IncomeExpenses>("/api/IncomeExpenses/UpdateIncomeExpenses", request);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IncomeExpenses);
                    }

                    return await response.Content.ReadFromJsonAsync<IncomeExpenses>();
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

        public async Task<IncomeExpensesDto> CreateIncomeExpensesAsync(IncomeExpensesDto incomeExpensesDto)
        {
            try
            {
                var response =
                    await _httpClient.PostAsJsonAsync<IncomeExpensesDto>("/api/IncomeExpenses/CreateIncomeExpenses", incomeExpensesDto);

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IncomeExpensesDto);
                    }

                    return await response.Content.ReadFromJsonAsync<IncomeExpensesDto>();
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

        public async Task<List<IncomeExpenses>> DeleteIncomeExpensesAsync(int id)
        {
            try
            {
                var response =
                    await _httpClient.DeleteAsync($"api/IncomeExpenses/DeleteIncomeExpenses?id={id}");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<IncomeExpenses>>();
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

        public async Task<IncomeExpenses> GetSingleIncomeExpensesAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/IncomeExpenses/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(IncomeExpenses);
                    }

                    return await response.Content.ReadFromJsonAsync<IncomeExpenses>();
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
