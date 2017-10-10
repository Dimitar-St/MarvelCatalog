using Marvel_Catalog_App.Data.Models;
using MarvelCatalog_App.Data.Repositories;
using MarvelCatalog_App.Data.UnitOfWork;
using MarvelCatalog_App.Services.Contracts;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MarvelCatalog_App.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEfRepository<User> usersRepository;

        public UserService(IUnitOfWork unitOfwork, IEfRepository<User> usersRepository)
        {
            this.unitOfWork = unitOfwork;
            this.usersRepository = usersRepository;
        }

        public void AddToFavoritesCharacters(IIdentity user, CharacterDataModel character)
        {
           //user.
        }

        public IIdentity CurrentUser()
        {
            return HttpContext.Current.User.Identity;
        }
    }
}
