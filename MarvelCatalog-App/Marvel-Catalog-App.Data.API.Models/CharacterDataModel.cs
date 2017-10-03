using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models
{
    public class CharacterDataModel : DataModel
    {
        public CharacterDataModel() { }

        public CharacterDataModel(string name, string image, string description, IDictionary<string, string> comments)
        {
            this.Name = name;
            this.Image = image;
            this.Description = description;
            this.Comments = comments;
        }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public IDictionary<string, string> Comments { get; set; }
    }
}
