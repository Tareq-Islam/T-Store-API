using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class SubCategoryEntity :CommonEntity
    {
        public bool Visiable { get; set; }
        public int fkCategoryID { get; set; }
        [ForeignKey("fkCategoryID")]
        public virtual CategoryEntity CategoryEntity { get; set; }
        public virtual ICollection<SubCategoryMGRefEntity> SubCategoryMGRefEntity { get; set; }

    }
}
