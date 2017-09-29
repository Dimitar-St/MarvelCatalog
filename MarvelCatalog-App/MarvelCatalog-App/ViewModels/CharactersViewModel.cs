using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.ViewModels
{
    public class CharactersViewModel
    {
        public CharactersViewModel(ICollection<CharacterViewModel> charactersViewModels)
        {
            this.CharactersViewModels = charactersViewModels;
        }

        public ICollection<CharacterViewModel> CharactersViewModels { get; private set; }
    }
}