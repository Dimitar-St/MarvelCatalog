using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using Bytes2you.Validation;

namespace MarvelCatalog_App.Services
{
    public class ComicsService : IComicsService
    {
        private readonly IEfRepository<ComicsDataModel> comics;
        private readonly IUnitOfWork unitOfWork;

        public ComicsService(IUnitOfWork unitOfwork, IEfRepository<ComicsDataModel> comicsRepository)
        {
            //Guard.WhenArgument(unitOfWork, nameof(unitOfWork)).IsNull().Throw();
            //Guard.WhenArgument(unitOfWork.ComicsRepository, nameof(unitOfWork.ComicsRepository)).IsNull().Throw();

            this.unitOfWork = unitOfwork;
            this.comics = comicsRepository;
        }

        public IEnumerable<ComicsDataModel> GetComics()
        {
            var wantedComics = this.comics.All
             .Where(comic => comic.isDeleted == false);

            return wantedComics;
        }

        public ComicsDataModel GetComic(string title)
        {
            Guard.WhenArgument(title, nameof(title)).IsNull().Throw();

            var searchedComic = this.comics.All.FirstOrDefault(c => c.Title == title);

            return searchedComic;
        }

        public void AddComic(ComicsDataModel comics)
        {
            Guard.WhenArgument(comics, nameof(comics)).IsNull().Throw();

            this.comics.Add(comics);

            this.unitOfWork.SaveChanges();
        }

        public void RemoveComic(string title)
        {
            Guard.WhenArgument(title, nameof(title)).IsNull().Throw();

            var comics = this.comics.All.FirstOrDefault(comic => comic.Title == title && comic.isDeleted == false);

            comics.isDeleted = true;

            this.unitOfWork.SaveChanges();
        }
    }
}
