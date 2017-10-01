using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.API.Models
{
    public class CharacterDataModel : DataModel
    {
        public CharacterDataModel() { }

        public CharacterDataModel(string name, string image, string description)
        {
            this.Name = name;
            this.Image = image;
            this.Description = description;
        }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }
    }
}
