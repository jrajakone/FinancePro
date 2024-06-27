using FinanceManagementTool1.Data;
using System.Collections;

namespace FinanceManagementTool1.Pages
{
    public partial class CurrencyExchange
    {
        string baseCurrency;
        string targetCurrency;
        double exchangeRate;
        double? eingabe;
        double nichtGerundeteWaehrung;
		double zielwaehrung; // mein Ziel
        IEnumerable<string> currencyTypes;

        protected async override Task OnInitializedAsync()
        {
            currencyTypes = await CurrencyService.GetCurrencyTypes();
        }

        private async Task GetExchangeRate()//OnButtonClick
        {
            currencyTypes.Contains(this.baseCurrency);// ja baseCurrency existiert
            currencyTypes.Contains(this.targetCurrency);// ja targetCurrency existiert

            //if() // existiert

            exchangeRate = await CurrencyService.GetExchangeRate(baseCurrency, targetCurrency);
			nichtGerundeteWaehrung = (double)(exchangeRate * eingabe);
			zielwaehrung = Math.Round(nichtGerundeteWaehrung, 2);
		}




		

		
		//void OnChange(double value, string name)
		//{

            
  //          eingabe = value;
		//	// console.Log($"{name} value changed to {value}");
		//}

	
}
}