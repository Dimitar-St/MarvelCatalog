using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarvelCatalog_App.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly IEfRepository<CharacterDataModel> characters;
        private readonly IUnitOfWork unitOfwork;

        public CharacterService(IUnitOfWork unitOfWork, IEfRepository<CharacterDataModel> charactersRepository)
        {
            Guard.WhenArgument(unitOfWork, nameof(unitOfWork)).IsNull().Throw();
            Guard.WhenArgument(charactersRepository, nameof(charactersRepository)).IsNull().Throw();

            this.unitOfwork = unitOfWork;
            this.characters = charactersRepository;
        }

        public IEnumerable<CharacterDataModel> GetCharacters()
        {
            var wantedCharacters =
                this.characters.All.Where(c => c.isDeleted == false);

            return wantedCharacters;
        }

        public CharacterDataModel GetCharacter(string name)
        {
            Guard.WhenArgument(name, nameof(name)).IsEmpty().IsNull().Throw();

            var wantedCharacter = this.characters.All.FirstOrDefault(c => c.Name == name);

            return wantedCharacter;
        }

        public IEnumerable<CharacterDataModel> GetAllCharactersAdministration()
        {
            var wantedCharacters =
                this.characters.All.Where(c => c.isDeleted == false || c.isDeleted == true);

            return wantedCharacters;
        }

        public CharacterDataModel GetCharacterById(int id)
        {
            var character = this.characters.All.FirstOrDefault(c => c.Id == id);

            return character;
        }

        public void AddCharacter(CharacterDataModel character)
        {
            Guard.WhenArgument(character, nameof(character)).IsNull().Throw();

            this.characters.Add(character);

            this.unitOfwork.SaveChanges();
        }

        public void RemoveCharacter(CharacterDataModel character)
        {
            Guard.WhenArgument(character, nameof(character)).IsNull().Throw();

            var characterToRemove = this.characters.All.First(c => c.isDeleted != true && c.Name == character.Name);

            characterToRemove.isDeleted = true;

            this.unitOfwork.SaveChanges();
        }

    }
}
