using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class ProductMGRefEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int fkMGID { get; set; }
        public int fkProductID { get; set; }
        [ForeignKey("fkProductID")]
        public virtual ProductEntity ProductEntities { get; set; }
        [ForeignKey("fkMGID")]
        public virtual MediaGalleryEntity MediaGalleryEntities { get; set; }


    }
}
