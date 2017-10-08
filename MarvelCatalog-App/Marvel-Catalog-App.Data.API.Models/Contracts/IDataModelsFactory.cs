using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models.Contracts
{
    public interface IDataModelsFactory
    {
        CharacterDataModel CreateCharacter(string name, string image, string description, IDictionary<string, string> comments);

        CharacterDataModel CreateCharacter();

        ComicsDataModel CreateComics(string title, string image, string description, double price, IEnumerable<CharacterDataModel> characters, IDictionary<string, string> comments);

        ComicsDataModel CreateComics();
    }
}
