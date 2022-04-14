using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class CharactersService : ICharactersService
    {
        public IEnumerable<Character> GetAll()
        {
            Task<Characters> taskCharacters;
            IRestClient apiClient = RestService.For<IRestClient>(RestClient.AmiiboBaseUrl); //Error: The SSL connection could not be established. 
            //IRestClient apiClient = RestService.For<IRestClient>(RestClient.HttpClientAmiibo());

            taskCharacters = Task.Run(
                async () => await apiClient.GetCharacters()
            );

            taskCharacters.Wait();

            return taskCharacters.Result.amiibo;
        }
    }
}
