using System;
using System.Collections.Generic;
using MarvelCatalog_App.Services.API.Contracts;
using System.Linq;
using System.Web;
using MarvelCatalog_App.Models;

namespace MarvelCatalog_App.ViewModels
{
    public class CharactersViewModel
    {
      public CharactersViewModel(ICollection<ICharacterModel> characters)
        {
            this.Characters = characters;
        }

        public ICollection<ICharacterModel> Characters { get; private set; }
    }
}