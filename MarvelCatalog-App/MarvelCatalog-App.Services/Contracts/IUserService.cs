using Marvel_Catalog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Services.Contracts
{
    public interface IUserService
    {
        IIdentity CurrentUser();
        
        void AddToFavoritesCharacters(IIdentity user, CharacterDataModel character);
    }
}
