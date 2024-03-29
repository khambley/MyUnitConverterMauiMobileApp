using System;
using System.Net.Http.Json;
using MyUnitConverter.Models;

namespace MyUnitConverter.Services
{
	public class RateService : IRateService, IDisposable
	{
        private bool disposedValue;

        const string UriBase = "https://api.currencyfreaks.com/v2.0";

        readonly HttpClient httpClient = new()
        {
            BaseAddress = new(UriBase),
            DefaultRequestHeaders = { { "user-agent", "maui-projects-unitconverter/1.0" } }
        };

        public RateService()
		{
		}

        public async Task<CurrencyRate> GetRates()
        {
            CurrencyRate result = new CurrencyRate();
            string url = UriBase + "/rates/latest?apikey=" + Settings.NewsApiKey;
            try
            {
                result = await httpClient.GetFromJsonAsync<CurrencyRate>(url);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"HTTP Get failed: {ex.Message}", "OK");
            }
            return result;
        }

        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    httpClient.Dispose();
                }
                disposedValue = true;
            }
        }
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}

