using Marvel_Catalog_App.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models.Factories
{
    public class DataModelsFactory : IDataModelsFactory
    {
        public DataModelsFactory() { }

        public CharacterDataModel CreateCharacter(string name, string image, string description, IDictionary<string, string> comments)
        {
            return new CharacterDataModel(name, image, description, comments);
        }

        public CharacterDataModel CreateCharacter()
        {
            return new CharacterDataModel();
        }

    }
}
