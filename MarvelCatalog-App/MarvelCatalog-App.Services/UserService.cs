using Bytes2you.Validation;
using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services.Contracts;
using System.Linq;

namespace MarvelCatalog_App.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEfRepository<User> usersRepository;

        public UserService(IUnitOfWork unitOfwork, IEfRepository<User> usersRepository)
        {
            Guard.WhenArgument(unitOfwork, nameof(unitOfwork)).IsNull().Throw();
            Guard.WhenArgument(usersRepository, nameof(usersRepository)).IsNull().Throw();

            this.unitOfWork = unitOfwork;
            this.usersRepository = usersRepository;
        }

        public void AddToFavoritesCharacters(string username, CharacterDataModel characterModel)
        {
            var user = this.usersRepository.All.FirstOrDefault(usr => usr.UserName == username);

            user.FavoritesCharacters.Add(characterModel);

            this.unitOfWork.SaveChanges();
        }
    }
}
