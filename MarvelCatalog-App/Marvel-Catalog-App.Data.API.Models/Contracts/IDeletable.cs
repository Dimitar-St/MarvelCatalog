using System;

namespace Marvel_Catalog_App.Data.Models.Contracts
{
    public interface IDeletable
    {
        bool isDeleted { get; set; }

        DateTime? DeletedOn { get; set; }
    }
}
