using MarvelCatalog_App.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.Models
{
    public class CharacterModel : ICharacterModel
    {
        public CharacterModel(int id, string name, string thumbnail)
        {
            this.Id = id;
            this.Name = name;
            this.Thumbnail = thumbnail;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
        
    }
}