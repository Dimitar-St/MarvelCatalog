using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models
{
    public class CharacterDataModel : DataModel
    {
        public CharacterDataModel() { }

        public CharacterDataModel(string name, string image, string description, string abilitiesDescription, string powers, string origin)
        {
            this.Name = name;
            this.Image = image;
            this.Description = description;
            this.AbilitiesDesctiption = abilitiesDescription;
            this.Powers = powers;
            this.Origin = origin;
        }
        
        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public string AbilitiesDesctiption { get; set; }

        public string Powers { get; set; }

        public string Origin { get; set; }
    }
}
