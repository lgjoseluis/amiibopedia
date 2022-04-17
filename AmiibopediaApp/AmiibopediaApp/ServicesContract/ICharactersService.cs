using System.Collections.Generic;
using System.Threading.Tasks;

using AmiibopediaApp.Models;

namespace AmiibopediaApp.ServicesContract
{
    public interface ICharactersService
    {
        Task<IEnumerable<Character>> GetAll();
    }
}
