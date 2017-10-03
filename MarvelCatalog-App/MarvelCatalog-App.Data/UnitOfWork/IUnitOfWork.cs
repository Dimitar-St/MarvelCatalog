using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();

        IEfRepository<CharacterDataModel> CharactersRepository { get; }

        IEfRepository<ComicsDataModel> ComicsRepository { get; }
    }
}
