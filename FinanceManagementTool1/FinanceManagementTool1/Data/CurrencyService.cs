using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace FinanceManagementTool1.Data
{
    public class CurrencyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public CurrencyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["APIKey"];
        }

        public async Task<double> GetExchangeRate(string baseCurrency, string targetCurrency)
        {
            var response = await _httpClient.GetAsync($"https://v6.exchangerate-api.com/v6/{_apiKey}/pair/{baseCurrency}/{targetCurrency}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            Currency result = JsonSerializer.Deserialize<Currency>(jsonString);
          
            return result.conversion_rate;
        }
        
        public async Task<string[]> GetCurrencyTypes()
        {
            var response = await _httpClient.GetAsync($"https://v6.exchangerate-api.com/v6/{_apiKey}/codes");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            CurrencyType result = JsonSerializer.Deserialize<CurrencyType>(jsonString);

            string[][] currencyNameAndShort = result.supported_codes;

            string[] currencyShort = new string[currencyNameAndShort.Length];

            // kopiere short aus dem currencyNameAndShort in currencyShort
            for ( int i = 0; i < currencyNameAndShort.Length; i++ )
            {
                currencyShort[i] = currencyNameAndShort[i][0];
            }
            return currencyShort;
        }
    }
}
