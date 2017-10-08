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
    }
}
