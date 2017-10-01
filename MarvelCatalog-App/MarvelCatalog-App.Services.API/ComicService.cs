using MarvelCatalog_App.Services.API.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarvelCatalog_App.Models;
using Marvel_Catalog_App.Data.API.Models;
using System.Net;
using Newtonsoft.Json.Linq;

namespace MarvelCatalog_App.Services.API
{
    public class ComicService : IComicsService
    {
        private readonly IJSONModelsFactory modelsFactory;

        public ComicService(IJSONModelsFactory modelsFactory)
        {
            this.modelsFactory = modelsFactory;
        }

        public ICollection<ComicModel> GetComics()
        {
            var url = "http://gateway.marvel.com/v1/public/characters?ts=1&apikey=33089e63dea73b570c975ace0bdce727&hash=eff5e80c387afc4f6de349fdfd235795";

            WebClient request = new WebClient();

            var data = request.DownloadString(url);

            var comicsJson = JObject.Parse(data)["data"]["results"];

            ICollection<ComicModel> comics = this.modelsFactory.MapComics(comicsJson);

            return comics;
        }
    }
}
