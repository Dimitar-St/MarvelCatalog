using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvelCatalog_App.Infrastructure
{
    public interface IMapperAdapter
    {
        T Map<T>(object objectToMap);
    }
}
