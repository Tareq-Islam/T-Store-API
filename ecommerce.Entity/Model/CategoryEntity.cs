using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class CategoryEntity : CommonEntity
    {
        public bool Visiable { get; set; }      
        public virtual ICollection<ProductEntity> ProductEntities { get; set; }
        public virtual ICollection<BrandMarkerEntity> BrandMarkerEntities { get; set; }
        public virtual ICollection<ModelEntity> ModelEntities { get; set; }
        public virtual ICollection<SubCategoryEntity> SubCategoryEntities { get; set; }
      
        

    }
}
