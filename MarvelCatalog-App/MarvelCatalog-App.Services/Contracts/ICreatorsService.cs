using Marvel_Catalog_App.Data.Models;
using System.Collections.Generic;

namespace MarvelCatalog_App.Services
{
    public interface ICreatorsService
    {
        IEnumerable<CreatorsDataModel> GetCreators();
    }
}