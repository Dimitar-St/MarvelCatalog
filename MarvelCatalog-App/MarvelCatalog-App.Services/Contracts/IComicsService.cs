using Marvel_Catalog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.Contracts
{
    public interface IComicsService
    {
        IEnumerable<ComicsDataModel> GetComics();

        ComicsDataModel GetComic(string title);

        void AddComic(ComicsDataModel comics);
    }
}
