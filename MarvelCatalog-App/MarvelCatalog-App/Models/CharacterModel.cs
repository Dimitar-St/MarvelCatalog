using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.Models
{
    public class CharacterModel
    {
        public CharacterModel() { }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}