using Marvel_Catalog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.ViewModels
{
    public class ComicsViewModel
    {
        public ComicsViewModel() { }

        public ComicsViewModel(string title, string image, string description, double price, IEnumerable<CharacterDataModel> characters, IDictionary<string, string> comments)
        {
            this.Title = title;
            this.Image = image;
            this.Description = description;
            this.Price = price;
            this.Characters = characters;
            this.Comments = comments;
        }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IEnumerable<CharacterDataModel> Characters { get; set; }

        public IDictionary<string, string> Comments { get; set; }
    }
}