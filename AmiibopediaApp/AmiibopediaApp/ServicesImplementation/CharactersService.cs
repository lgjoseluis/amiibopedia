using AmiibopediaApp.Helpers;
using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class CharactersService : ICharactersService
    {
        public IEnumerable<Character> GetAll()
        {
            string urlService = "https://amiiboapi.com/api/character/";
            HttpHelper<Characters> serviceHttp = new HttpHelper<Characters>();
            Task<Characters> taskCharacters = Task.Run(async () => await serviceHttp.GetDataFromRestServiceAsync(urlService));

            taskCharacters.Wait();

            return taskCharacters.Result.amiibo;
        }
    }
}
