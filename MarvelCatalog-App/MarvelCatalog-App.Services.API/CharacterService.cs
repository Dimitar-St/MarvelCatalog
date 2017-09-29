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

namespace MarvelCatalog_App.Services.API
{
    public class CharacterService : ICharacterService
    {
        private readonly IJSONModelsFactory modelsFactory;

        public CharacterService(IJSONModelsFactory modelsfactory)
        {
            this.modelsFactory = modelsfactory;
        }
        
        public ICollection<CharacterModel> GetCharecters()
        {
            var url = "http://gateway.marvel.com/v1/public/characters?ts=1&apikey=33089e63dea73b570c975ace0bdce727&hash=eff5e80c387afc4f6de349fdfd235795";

            WebClient request = new WebClient();

            var data = request.DownloadString(url);

            var charactersJson = JObject.Parse(data)["data"]["results"];

            ICollection<CharacterModel> characters = this.modelsFactory.MapCharacters(charactersJson);

            return characters;
        }
    }
}
