using AmiibopediaApp.Models;
using AmiibopediaApp.ServicesContract;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesImplementation
{
    public class AmiibosService : IAmiibosService
    {
        public async Task<IEnumerable<Amiibo>> GetAllByCharacter(string character)
        {
            Amiibos amiibos;            
            IRestClient apiClient = RestService.For<IRestClient>(RestClient.HttpClientAmiibo());
                        
            amiibos = await apiClient.GetAmiibos(character);

            return amiibos.amiibo;
        }
    }
}
