using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Model
{
    public partial class ConvertCoinModel : ObservableRecipient
    {
        [ObservableProperty]
        private Currency mainCoin;

        public class Currency
        {
            private double currencyConverted;
            public double CurrencyConverted 
            {
                get => currencyConverted;
                set
                {
                    currencyConverted = value;
                }
            }
        }
    }


}
