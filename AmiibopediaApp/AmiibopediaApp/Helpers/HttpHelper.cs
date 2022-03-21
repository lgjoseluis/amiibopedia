using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AmiibopediaApp.Helpers
{
    public class HttpHelper<T> where T : class
    {
        public async Task<T> GetDataFromRestServiceAsync(string serviceAddress)
        {
            T result;
            string jsonResult;
            HttpResponseMessage response;
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(serviceAddress);

            response = await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            jsonResult = await response.Content.ReadAsStringAsync();
            result = JsonConvert.DeserializeObject<T>(jsonResult);

            return result;
        }
    }
}
