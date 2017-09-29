using MarvelCatalog_App.Models;
using MarvelCatalog_App.Services.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.API
{
    public class JSONModelsDactory : IJSONModelsFactory
    {
        public JSONModelsDactory() { }

        public CharacterModel MapCharcterModel(dynamic obj)
        {
            var id = int.Parse(obj["id"].ToString());
            var name = obj["name"].ToString();
            var image = obj["thumbnail"]["path"].ToString() + ".jpg";

            var characterModel = new CharacterModel(id, name, image);

            return characterModel;
        }

        public ICollection<CharacterModel> MapCharacters(dynamic characters)
        {
            ICollection<CharacterModel> mappedCharacters = new List<CharacterModel>();

            foreach (var character in characters)
            {
                mappedCharacters.Add(this.MapCharcterModel(character));
            }

            return mappedCharacters;
        }
    }
}
