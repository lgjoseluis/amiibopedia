using AmiibopediaApp.Helpers;
using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class AmiibosService : IAmiibosService
    {
        public IEnumerable<Amiibo> GetAllByCharacter(string character)
        {
            string urlService = $"https://amiiboapi.com/api/amiibo/?character={character}";
            HttpHelper<Amiibos> serviceHttp = new HttpHelper<Amiibos>();
            Task<Amiibos> taskCharacters = Task.Run<Amiibos>( () => serviceHttp.GetDataFromRestServiceAsync(urlService));

            taskCharacters.Wait();

            return taskCharacters.Result.amiibo;
        }
    }
}
