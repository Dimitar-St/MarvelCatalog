using Marvel_Catalog_App.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.Areas.Admin.Models
{
    public class ComicsAdminViewModel
    {
        public ComicsAdminViewModel(int id, DateTime createdOn, DateTime deletedOn, bool isDeleted, DateTime modifiedOn, string title, string image, string description, double price, IEnumerable<CharacterDataModel> characters, IDictionary<string, string> comments)
        {
            this.Id = id;
            this.CreatedOn = createdOn;
            this.DeletedOn = deletedOn;
            this.isDeleted = isDeleted;
            this.ModifiedOn = modifiedOn;
            this.Title = title;
            this.Image = image;
            this.Description = description;
            this.Price = price;
            this.Characters = characters;
            this.Comments = comments;
        }

        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public bool isDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public IEnumerable<CharacterDataModel> Characters { get; set; }

        public IDictionary<string, string> Comments { get; set; }
    }
}