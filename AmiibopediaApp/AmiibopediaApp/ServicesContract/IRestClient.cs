using AmiibopediaApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AmiibopediaApp.ServicesContract
{
    public interface IRestClient
    {
        [Get("/character")]
        Task<Characters> GetCharacters();

        [Get("/amiibo/?character={character}")]
        Task<Amiibos> GetAmiibos(string character);
    }
}
