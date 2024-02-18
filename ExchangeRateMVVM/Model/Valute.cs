using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateMVVM.Model
{
    public class CurrencyRates
    {
        [JsonProperty("Date")]
        public DateTime Date { get; set; }

        [JsonProperty("PreviousDate")]
        public DateTime PreviousDate { get; set; }

        [JsonProperty("PreviousURL")]
        public string PreviousURL { get; set; }

        [JsonProperty("Timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty("Valute")]
        public Dictionary<string, Valute> Valutes { get; set; }
    }

    public class Valute
    {
        [JsonProperty("ID")]
        public string ID { get; set; }

        [JsonProperty("NumCode")]
        public string NumCode { get; set; }

        [JsonProperty("CharCode")]
        public string CharCode { get; set; }

        [JsonProperty("Nominal")]
        public int Nominal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Value")]
        public double Value { get; set; }

        [JsonProperty("Previous")]
        public double Previous { get; set; }

        public double Convert(Valute selectedValuteDest, double amountSrc)
        {
            return amountSrc * this.Value / selectedValuteDest.Value;
        }  
    }
}
