using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.Areas.Admin.Models
{
    public class CharactersAdminViewModel
    {
        public CharactersAdminViewModel() { }

        public CharactersAdminViewModel(int id, DateTime createdOn, DateTime deletedOn, bool isDeleted, DateTime modifiedOn, string name, string image, string description)
        {
            this.Id = id;
            this.CreatedOn = createdOn;
            this.DeletedOn = deletedOn;
            this.isDeleted = isDeleted;
            this.ModifiedOn = modifiedOn;
            this.Name = name;
            this.Image = image;
            this.Description = description;
        }

        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }
        
        public bool isDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public IDictionary<string, string> Comments { get; set; }
    }
}