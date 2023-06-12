using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinCheck.Model
{
    public partial class Ath : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class AthChangePercentage : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class Atl : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class AtlChangePercentage : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class CurrentPrice : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class FullyDilutedValuation : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public long usd;
    }

    public partial class High24h : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class Low24h : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class MarketCap : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public long usd;
    }

    public partial class MarketCapChange24hInCurrency : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public long usd;
    }

    public partial class MarketCapChangePercentage24hInCurrency : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    [JsonObject("market_data")]
    public partial class MarketData : ObservableRecipient
    {
        [JsonProperty("current_price")]
        [ObservableProperty]
        public CurrentPrice current_price;

        [JsonProperty("ath")]
        [ObservableProperty]
        public Ath ath;

        [JsonProperty("ath_change_percentage")]
        [ObservableProperty]
        public AthChangePercentage ath_change_percentage;

        [JsonProperty("atl")]
        [ObservableProperty]
        public Atl atl;

        [JsonProperty("atl_change_percentage")]
        [ObservableProperty]
        public AtlChangePercentage atl_change_percentage;

        [JsonProperty("market_cap")]
        [ObservableProperty]
        public MarketCap market_cap;

        [JsonProperty("market_cap_rank")]
        [ObservableProperty]
        public int market_cap_rank;

        [JsonProperty("fully_diluted_valuation")]
        [ObservableProperty]
        public FullyDilutedValuation fully_diluted_valuation;

        [JsonProperty("total_volume")]
        [ObservableProperty]
        public Currency total_volume;

        [JsonProperty("high_24h")]
        [ObservableProperty]
        public High24h high_24h;

        [JsonProperty("low_24h")]
        [ObservableProperty]
        public Low24h low_24h;

        [JsonProperty("price_change_24h")]
        [ObservableProperty]
        public double price_change_24h;

        [JsonProperty("price_change_percentage_24h")]
        [ObservableProperty]
        public double price_change_percentage_24h;

        [JsonProperty("price_change_percentage_7d")]
        [ObservableProperty]
        public double price_change_percentage_7d;

        [JsonProperty("price_change_percentage_14d")]
        [ObservableProperty]
        public double price_change_percentage_14d;

        [JsonProperty("market_cap_change_24h")] 
        [ObservableProperty]
        public long market_cap_change_24h;

        [JsonProperty("market_cap_change_percentage_24h")]
        [ObservableProperty]
        public double market_cap_change_percentage_24h;

        [JsonProperty("price_change_24h_in_currency")]
        [ObservableProperty]
        public Currency price_change_24h_in_currency;

        [JsonProperty("price_change_percentage_1h_in_currency")]
        [ObservableProperty]
        public Currency price_change_percentage_1h_in_currency;

        [JsonProperty("price_change_percentage_24h_in_currency")]
        [ObservableProperty]
        public Currency price_change_percentage_24h_in_currency;

        [JsonProperty("price_change_percentage_7d_in_currency")]
        [ObservableProperty]
        public Currency price_change_percentage_7d_in_currency;

        [JsonProperty("price_change_percentage_14d_in_currency")]
        [ObservableProperty]
        public Currency price_change_percentage_14d_in_currency;

        [JsonProperty("market_cap_change_24h_in_currency")]
        [ObservableProperty]
        public MarketCapChange24hInCurrency market_cap_change_24h_in_currency;
    }

    public partial class Currency : ObservableRecipient
    {
        [JsonProperty("usd")]
        [ObservableProperty]
        public double usd;
    }

    public partial class Market : ObservableRecipient
    {
        [JsonProperty("name")]
        [ObservableProperty]
        private string coinName;

        [ObservableProperty]
        private string identifier;

        [ObservableProperty]
        private bool has_trading_incentive;
    }
    public partial class ConvertedValue : ObservableRecipient
    {
        [ObservableProperty]
        private double btc;

        [ObservableProperty]
        private double eth;

        [ObservableProperty]
        private double usd;
    }
    public partial class Ticker : ObservableRecipient
    {
        [JsonProperty("base")]
        [ObservableProperty]
        private string based;

        [ObservableProperty]
        private string target;

        [ObservableProperty]
        private Market market;

        [ObservableProperty]
        private double last;

        [ObservableProperty]
        private double volume;

        [ObservableProperty]
        private ConvertedValue converted_last;

        [ObservableProperty]
        private ConvertedValue converted_volume;

        [ObservableProperty]
        private string trust_score;

        [ObservableProperty]
        private double bid_ask_spread_percentage;

        [ObservableProperty]
        private DateTime timestamp;

        [ObservableProperty]
        private DateTime last_traded_at;

        [ObservableProperty]
        private DateTime last_fetch_at;

        [ObservableProperty]
        private bool is_anomaly;

        [ObservableProperty]
        private bool is_stale;

        [ObservableProperty]
        private string trade_url;

        [ObservableProperty]
        private object token_info_url;

        [ObservableProperty]
        private string coin_id;

        [ObservableProperty]
        private string target_coin_id;
    }

}
