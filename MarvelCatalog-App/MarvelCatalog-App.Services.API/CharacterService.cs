using MarvelCatalog_App.Services.API.Contracts;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MarvelCatalog_App.Models;
using Marvel_Catalog_App.Data.API.Models.JSONDataModel;

namespace MarvelCatalog_App.Services.API
{
    public class CharacterService : ICharacterService
    {
        private readonly IJSONModelsFactory modelsFactory;

        public CharacterService(IJSONModelsFactory modelsfactory)
        {
            this.modelsFactory = modelsfactory;
        }
        
        public RootObject Get()
        {
            var url = "http://gateway.marvel.com/v1/public/characters?ts=1&apikey=33089e63dea73b570c975ace0bdce727&hash=eff5e80c387afc4f6de349fdfd235795";

            WebClient request = new WebClient();

            var data = request.DownloadString(url);

            var charactersJson = JObject.Parse(data)["data"]["results"];
            var jsonConvert = JsonConvert.DeserializeObject<RootObject>(data);


            ICollection<CharacterModel> characters = this.modelsFactory.MapCharacters(charactersJson);

            return jsonConvert;
        }
    }
}
