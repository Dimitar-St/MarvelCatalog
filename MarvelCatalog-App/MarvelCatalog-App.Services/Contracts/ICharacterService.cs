using Marvel_Catalog_App.Data.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.Contracts
{
    public interface ICharacterService
    {
        IEnumerable<CharacterDataModel> GetCharacters();
    }
}
