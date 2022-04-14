using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace AmiibopediaApp.ServicesImplementation
{
    internal class RestClient
    {
        public static string AmiiboBaseUrl => "https://www.amiiboapi.com/api";

        protected RestClient() { }

        public static HttpClient HttpClientAmiibo() 
        {
            HttpClient httpClient = new HttpClient()
            {
                BaseAddress = new Uri(AmiiboBaseUrl)
            };

            return httpClient; 
        }
        
    }
}
