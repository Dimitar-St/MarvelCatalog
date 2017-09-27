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

        public static CharacterModel Map(dynamic obj)
        {
            var id = int.Parse(obj["id"].ToString());
            var name = obj["name"].ToString();
            var image = obj["thumbnail"]["path"].ToString() + "jpg";

            var characterModel = new CharacterModel(id, name, image);

            return characterModel;  
        } 

        public static ICollection<ICharacterModel> MapCollection(dynamic characters)
        {
            ICollection<ICharacterModel> mappedCharacters = new List<ICharacterModel>();

            foreach (var character in characters)
            {
                mappedCharacters.Add(CharacterModel.Map(character));
            }

            return mappedCharacters;
        }
    }
}