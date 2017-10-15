using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MarvelCatalog_App.Models;

namespace MarvelCatalog_App.ViewModels
{
    public class CharacterViewModel
    {
        public CharacterViewModel() { }

        public CharacterViewModel(string name, string image, string description, string powers, string origin, string abilitiesDesctiption)
        {
            this.Name = name;
            this.Image = image;
            this.Description = description;
            this.Powers = powers;
            this.Origin = origin;
            this.AbilitiesDesctiption = abilitiesDesctiption;
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string AbilitiesDesctiption { get; set; }

        public string Powers { get; set; }

        public string Origin { get; set; }
    }
}