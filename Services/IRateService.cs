using System;
using MyUnitConverter.Models;

namespace MyUnitConverter.Services
{
	public interface IRateService
	{
		public Task<CurrencyRate> GetRates();
	}
}

