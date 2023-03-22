using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PtototypeNameSpace 
{

}

namespace PtototypeNameSpace.JsonGet
{
    public class CryptobankJSONGetter
    {
        private const string URL = "https://api.cryptorank.io/v1/currencies";
        private const string baseUrlParamerters = "?api_key=PUT_API_KEY_HERE&limit=10";

        public string GetJsonFromAPI(string query = "")
        {
            string result = String.Empty;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(URL);

            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(baseUrlParamerters + query).Result;
            if (response.IsSuccessStatusCode)
            {
                result = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            client.Dispose();
            return result;
        }
    }

    public struct APIData
    {
        public int id;
        public string symbol;
        public string name;
        public string type;
        public string category;
        public float price;
        public float high24h;
        public float low24h;
        public float percentChange24h;
        public float percentChange7d;
        public float percentChange30d;
        public float percentChange3m;
        public float percentChange6m;

        public APIData(int id, string symbol, string name,
                        string type, string category, float price,
                        float high24h, float low24h, float percentchange24h,
                        float percentchange7d, float percentchange30d, float percentchange3m, float percentchange6m)
        {
            this.id = id;
            this.symbol = symbol;
            this.name = name;
            this.type = type;
            this.category = category;
            this.price = price;
            this.high24h = high24h;
            this.low24h = low24h;
            this.percentChange24h = percentchange24h;
            this.percentChange7d = percentchange7d;
            this.percentChange30d = percentchange30d;
            this.percentChange3m = percentchange3m;
            this.percentChange6m = percentchange6m;
        }

        public static List<APIData> ConvertJsonToAPIDatas(string json)
        {
            if (json == null || json == String.Empty) return null;

            List<APIData> result = new List<APIData>();

            dynamic dynamicJson = JsonConvert.DeserializeObject<dynamic>(json);

            dynamic data = dynamicJson.data;

            List<dynamic> list = new List<dynamic>();

            foreach(var item in data)
            {
                list.Add(item);
            }

            foreach(var item in list)
            {
                APIData res = new APIData();

                try
                {
                    string deb = "";

                    dynamic USD = item.values.USD;

                    res.symbol = item.symbol;

                    deb = item.id;
                    res.id = int.Parse(deb);

                    res.name = item.name;

                    res.type = item.type;

                    res.category = item.category;

                    deb = USD.price;
                    res.price = float.Parse(deb, CultureInfo.InvariantCulture);

                    deb = USD.high24h;
                    res.high24h = float.Parse(deb, CultureInfo.InvariantCulture);

                    deb = USD.low24h;
                    res.low24h = float.Parse(deb, CultureInfo.InvariantCulture);

                    try
                    {
                        deb = USD.percentChange24h;
                        res.percentChange24h = float.Parse(deb, CultureInfo.InvariantCulture);

                        deb = USD.percentChange7d;
                        res.percentChange7d = float.Parse(deb, CultureInfo.InvariantCulture);

                        deb = USD.percentChange30d;
                        res.percentChange30d = float.Parse(deb, CultureInfo.InvariantCulture);

                        deb = USD.percentChange3m;
                        res.percentChange3m = float.Parse(deb, CultureInfo.InvariantCulture);

                        deb = USD.percentChange6m;
                        res.percentChange6m = float.Parse(deb, CultureInfo.InvariantCulture);
                    }
                    catch
                    {

                    }
                    result.Add(res);
                }
                catch
                {

                }
            }
            return result;
        }
    }

    public class ClockGenerator
    {
        const double delay = 10;

        public void Update()
        {
            Task.Delay(TimeSpan.FromSeconds(delay));

            Console.WriteLine("Тик\n");

        }




    }


}



