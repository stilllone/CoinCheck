using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoinCheck.Model
{
    public partial class ConvertCoinModel : ObservableRecipient
    {
        [ObservableProperty]
        private Dictionary<string, double> mainCoin;

    }
    public class CustomConverter : Newtonsoft.Json.JsonConverter<ConvertCoinModel>
    {
        public override ConvertCoinModel ReadJson(JsonReader reader, Type objectType, ConvertCoinModel existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var jsonObject = JObject.Load(reader);

            var bitcoinData = new ConvertCoinModel
            {
                MainCoin = new Dictionary<string, double>()
            };

            var bitcoinObject = jsonObject["bitcoin"];
            if (bitcoinObject != null && bitcoinObject.Type == JTokenType.Object)
            {
                foreach (var property in bitcoinObject.Value<JObject>().Properties())
                {
                    var key = property.Name;
                    var value = property.Value.Value<double>();

                    bitcoinData.MainCoin.Add(key, value);
                }
            }

            return bitcoinData;
        }

        public override void WriteJson(JsonWriter writer, ConvertCoinModel value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }

}
