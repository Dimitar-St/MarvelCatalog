using System;
using System.Collections.Generic;
using MarvelCatalog_App.Services.API.Contracts;
using System.Linq;
using System.Web;
using MarvelCatalog_App.Models;

namespace MarvelCatalog_App.ViewModels
{
    public class CharacterViewModel
    {
        public CharacterViewModel(int id, string name, string thumbnail)
        {
            this.Id = id;
            this.Name = name;
            this.Thumbnail = thumbnail;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Thumbnail { get; set; }
    }
}