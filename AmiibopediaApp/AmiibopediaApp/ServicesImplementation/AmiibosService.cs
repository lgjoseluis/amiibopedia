using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class AmiibosService : IAmiibosService
    {
        public IEnumerable<Amiibo> GetAllByCharacter(string character)
        {
            Task<Amiibos> taskCharacters;            
            IRestClient apiClient = RestService.For<IRestClient>(RestClient.HttpClientAmiibo());
                        
            taskCharacters = Task.Run(
                async () => await apiClient.GetAmiibos(character)
            );

            taskCharacters.Wait();

            return taskCharacters.Result.amiibo;
        }
    }
}
