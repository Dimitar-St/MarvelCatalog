using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models
{
    public class CreatorsDataModel : DataModel
    {
        public CreatorsDataModel() { }

        public CreatorsDataModel(string fullName, string image, int age, string description, string career, Dictionary<string, string> comments)
        {
            this.FullName = fullName;
            this.Age = age;
            this.Description = description;
            this.Career = career;
            this.Comments = comments;
            this.Image = image;
        }

        public int Age { get; set; }

        public string Career { get; set; }

        public Dictionary<string, string> Comments { get; private set; }

        public string Description { get; set; }

        public string FullName { get; set; }

        public string Image { get; set; }
    }
}
