using AmiibopediaApp.Models;
using System.Collections.Generic;

namespace AmiibopediaApp.ServicesContract
{
    public interface IAmiibosService
    {
        IEnumerable<Amiibo> GetAllByCharacter(string character);
    }
}
