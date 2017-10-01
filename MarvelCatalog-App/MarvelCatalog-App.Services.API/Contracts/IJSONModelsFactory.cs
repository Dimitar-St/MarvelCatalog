using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.API.Contracts
{
    public interface IJSONModelsFactory
    {
        CharacterModel MapCharcterModel(dynamic obj);

        ICollection<CharacterModel> MapCharacters(dynamic characters);

        ICollection<ComicModel> MapComics(dynamic obj);
    }
}
