using Marvel_Catalog_App.Data.Models;
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

        CharacterDataModel GetCharacter(string name);

        IEnumerable<CharacterDataModel> GetAllCharactersAdministration();

        CharacterDataModel GetCharacterById(int id);
    }
}
