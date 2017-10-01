using System;

namespace Marvel_Catalog_App.Data.API.Models.Contracts
{
    public interface IDeletable
    {
        bool isDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
