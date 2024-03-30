using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyUnitConverter.Models;
using MyUnitConverter.Services;

namespace MyUnitConverter.ViewModels
{
	public partial class MainViewModel : ViewModelBase
	{
		private readonly IRateService rateService;

		[ObservableProperty]
		private CurrencyRate? currencyRate;

		[ObservableProperty]
		ObservableCollection<string>? baseNames;

		[ObservableProperty]
		decimal unitValue;

		[ObservableProperty]
		string? selectedFromCurrency;

        [ObservableProperty]
        string? selectedToCurrency;

        [ObservableProperty]
        decimal conversionResult;

        public MainViewModel(IRateService rateService)
		{
			this.rateService = rateService;
			SetBaseNames();
			
		}

        private void SetBaseNames()
        {
            BaseNames = new ObservableCollection<string>()
            {
                "MXN - Mexican Peso",
                "GBP - Pound Sterling",
                "EUR - Euro",
                "BTC - Bitcoin",
                "CAD - Canadian Dollar",
                "JPY - Japanese Yen",
                "RUB - Russian Ruble",
                "USD - US Dollar",
            };
        }

        [RelayCommand]
		public async Task GetRatesAsync()
		{
			var newBaseFrom = SelectedFromCurrency?.Split(' ')[0];
            var newBaseTo = SelectedToCurrency?.Split(' ')[0];

            CurrencyRate = await rateService.GetRates(newBaseFrom ?? "");

            decimal convertRate = 0;
		
			switch (newBaseTo)
			{
				case "MXN":
					convertRate = decimal.Parse(CurrencyRate.Rate?.MXN != null ? CurrencyRate.Rate.MXN : "");
					break;
				case "GBP":
                    convertRate = decimal.Parse(CurrencyRate.Rate?.GBP != null ? CurrencyRate.Rate.GBP : "");
                    break;
                case "EUR":
                    convertRate = decimal.Parse(CurrencyRate.Rate?.EUR != null ? CurrencyRate.Rate.EUR : "");
                    break;
                case "BTC":
                    convertRate = decimal.Parse(CurrencyRate.Rate?.BTC != null ? CurrencyRate.Rate.BTC : "");
                    break;
                case "CAD":
                    convertRate = decimal.Parse(CurrencyRate.Rate.CAD);
                    break;
                case "JPY":
                    convertRate = decimal.Parse(CurrencyRate.Rate.JPY);
                    break;
                case "RUB":
                    convertRate = decimal.Parse(CurrencyRate.Rate.RUB);
                    break;
                case "USD":
                    convertRate = decimal.Parse(CurrencyRate.Rate.USD);
                    break;
                default:
                    Application.Current.MainPage.DisplayAlert("Error", "No matching currency found", "OK");
                    break;
            }

            ConversionResult = unitValue * convertRate;
        }


	}
}

