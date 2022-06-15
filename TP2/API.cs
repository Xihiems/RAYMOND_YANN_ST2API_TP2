using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2
{
    public class Api
    {
        private readonly HttpClient _client;
        private static string _url = "https://api.openweathermap.org/data/2.5/onecall";
        private readonly string _key;

        public Api()
        {
            _client = new HttpClient();
            _key = "9a692dcccf4a05a3cae8c9069c1ac13a";
        }

        public Root GetValuesBySymbol(Coordinates coordinates)
        {

            string url = $"{_url}?lat={coordinates._latitude}&lon={coordinates._longitude}&units=metric&appid={_key}";

            var json = GetGlobalDataAsync(url).GetAwaiter().GetResult();
            Root data = JsonConvert.DeserializeObject<Root>(json);

            return data;
        }

        public async Task<string> GetGlobalDataAsync(string url)
        {
            var data = string.Empty;
            var response = await _client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsStringAsync();
            }
            return data;
        }
    }
}
