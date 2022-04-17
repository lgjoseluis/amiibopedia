using System.Collections.Generic;
using System.Threading.Tasks;

using AmiibopediaApp.Models;

namespace AmiibopediaApp.ServicesContract
{
    public interface IAmiibosService
    {
        Task<IEnumerable<Amiibo>> GetAllByCharacter(string character);
    }
}
