using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Models;
using MarvelCatalog_App.Services.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.API
{
    public class JSONModelsFactory : IJSONModelsFactory
    {
        public JSONModelsFactory() { }

        public CharacterModel MapCharcterModel(dynamic obj)
        {
            var id = int.Parse(obj["id"].ToString());
            var name = obj["name"].ToString();
            var image = obj["thumbnail"]["path"].ToString() + ".jpg";

            var characterModel = new CharacterModel(id, name, image);

            return characterModel;
        }

        public ComicModel MapComicsModel(dynamic comics)
        {
            var idMarvel = int.Parse(comics["id"].ToString());
            var title = comics["title"].ToString();
            var description = comics["description"];
            var isbn = comics["isbn"];
            var pageCount = int.Parse(comics["pageCount"]);
            var price = comics["prices"][0]["price"];
            var image = comics["thumbnail"]["path"].ToString() + ".jpg";

            return new ComicModel(idMarvel, title, description, isbn, pageCount, image, price);
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

        public ICollection<ComicModel> MapComics(dynamic comicsMervel)
        {
            ICollection<ComicModel> mappedComics = new List<ComicModel>();

            foreach (var comics in comicsMervel)
            {
                mappedComics.Add(this.MapComicsModel(comics));
            }

            return mappedComics;
        }
    }
}
