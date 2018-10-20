using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class MediaGalleryEntity : CommonEntity
    {
      
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ShortDetails { get; set; }
        public bool IsDefault { get; set; }
       
        public virtual ICollection<ProductMGRefEntity> ProductMGRefEntity { get; set; }
     
        public virtual ICollection<SubCategoryMGRefEntity> SubCategoryMGRefEntity { get; set; }
      
       


    }
}
