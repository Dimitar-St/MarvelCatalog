using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IEfRepository<CharacterDataModel> characters;

        public CharacterService(IEfRepository<CharacterDataModel> charatcers)
        {
            this.characters = charatcers;
        }

        public IEnumerable<CharacterDataModel> GetCharacters()
        {
            var wantedCharacters =
                this.characters.All.Where(c => c.isDeleted == false);

            return wantedCharacters;
        }

        public CharacterDataModel GetCharacter(string name)
        {
            var wantedCharacter = this.characters.All.First(c => c.Name == name);

            return wantedCharacter;
        }

    }
}
