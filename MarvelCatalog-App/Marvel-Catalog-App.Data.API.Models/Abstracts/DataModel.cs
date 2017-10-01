using Marvel_Catalog_App.Data.Models.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marvel_Catalog_App.Data.Models
{
    public abstract class DataModel : IAuditable, IDeletable
    {
        public DataModel()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Index]
        public bool isDeleted { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
