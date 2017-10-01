using Marvel_Catalog_App.Data.API.Models;
using MarvelCatalog_App.Services;
using MarvelCatalog_App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Common
{
    public class MapperService : IMapperService
    {
        public MapperService() { }

        public ICollection<CharacterViewModel> MapCollcetion(IEnumerable<CharacterDataModel> dataModels)
        {
            ICollection<CharacterViewModel> viewModels = new List<CharacterViewModel>();

            foreach (var model in dataModels)
            {
                var mappedModel = this.MapCharacterDataModel(model);

                viewModels.Add(mappedModel);
            }

            return viewModels;
        }

        public CharacterViewModel MapCharacterDataModel(CharacterDataModel dataModel)
        {
            var viewModel = new CharacterViewModel(dataModel.Name, dataModel.Image, dataModel.Description);

            return viewModel;
        }
    }
}
