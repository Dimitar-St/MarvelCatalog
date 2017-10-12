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

        public CharacterViewModel(string name, string image, string description)
        {
            this.Name = name;
            this.Image = image;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string AbilitiesDesctiption { get; set; }

        public string Powers { get; set; }

        public string Origin { get; set; }
    }
}