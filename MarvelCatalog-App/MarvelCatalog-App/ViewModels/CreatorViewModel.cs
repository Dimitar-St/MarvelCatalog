using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelCatalog_App.ViewModels
{
    public class CreatorViewModel
    {
        public CreatorViewModel(string fullName, string image, int age, string description, string career, Dictionary<string, string> comments)
        {
            this.FullName = fullName;
            this.Age = age;
            this.Description = description;
            this.Career = career;
            this.Comments = comments;
            this.Image = image;
        }

        public int Age { get; private set; }

        public string Career { get; private set; }

        public Dictionary<string, string> Comments { get; private set; }

        public string Description { get; private set; }

        public string FullName { get; private set; }

        public string Image { get; private set; }
    }
}