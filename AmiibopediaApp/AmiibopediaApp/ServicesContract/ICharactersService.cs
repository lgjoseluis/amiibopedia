using AmiibopediaApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AmiibopediaApp.ServicesContract
{
    public interface ICharactersService
    {
        IEnumerable<Character> GetAll();
    }
}
