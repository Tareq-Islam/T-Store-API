using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class SubCategoryMGRefEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int fkMGID { get; set; }
        public int fkSubCategoryID { get; set; }
        [ForeignKey("fkSubCategoryID")]
        public virtual SubCategoryEntity SubCategoryEntity { get; set; }
        [ForeignKey("fkMGID")]
        public virtual MediaGalleryEntity MediaGalleryEntity { get; set; }
    }
}
