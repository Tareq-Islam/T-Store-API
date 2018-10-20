using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Entity.Model
{
    public class ModelEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int fkCategoryID { get; set; }

        public string ModelName { get; set; }
        [ForeignKey("fkCategoryID")]
        public virtual CategoryEntity CategoryEntity { get; set; }
        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
    }
}
