using AutoMapper;
using MarvelCatalog_App.Infrastructure;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MarvelCatalog_App.App_Start
{
    public class AutoMapperConfig : IMapperAdapter
    {
        public T Map<T>(object objectToMap)
        {
            //Mapper.Map is a static method of the library!
            return Mapper.Map<T>(objectToMap);
        }
    }
}