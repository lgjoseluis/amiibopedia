using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class CharactersService : ICharactersService
    {
        public async Task<IEnumerable<Character>> GetAll()
        {            
            Characters characters;
            //IRestClient apiClient = RestService.For<IRestClient>(RestClient.AmiiboBaseUrl); //Error: The SSL connection could not be established. 
            IRestClient apiClient = RestService.For<IRestClient>(RestClient.HttpClientAmiibo());

            characters = await apiClient.GetCharacters();

            return characters.amiibo;
        }
    }
}
