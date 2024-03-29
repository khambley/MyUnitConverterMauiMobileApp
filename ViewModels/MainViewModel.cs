using System;
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

		public List<string>? CurrencyNames { get; set; }

		public MainViewModel(IRateService rateService)
		{
			this.rateService = rateService;
		}

		[RelayCommand]
		public async Task GetRatesAsync()
		{
            CurrencyRate = await rateService.GetRates();
        }

	}
}

