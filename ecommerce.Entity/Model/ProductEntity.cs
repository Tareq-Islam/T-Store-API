using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class ProductEntity : CommonEntity
    {
        public int fkCategoryID { get; set; }
        public int? fkBrandMakerID { get; set; }
        public int? fkModelID { get; set; }

        public long Price { get; set; }
        public string ReturnPolicy { get; set; }
        public string WarrentlyPolicy { get; set; }
        public string SellerService { get; set; }
        public string ProductFeature { get; set; }
        public string PlaceOfOrgin { get; set; }
        public long BarCode { get; set; }
        public long QRCode { get; set; }
        public long RFID { get; set; }
        public long UPC { get; set; }
        public long SKU { get; set; }
        public long IsCustomizable { get; set; }
        [ForeignKey("fkCategoryID")]
        public virtual CategoryEntity  CategoryEntity { get; set; }
        [ForeignKey("fkBrandMakerID")]
        public virtual BrandMarkerEntity BrandMarkerEntity  { get; set; }
        [ForeignKey("fkModelID")]
        public virtual ModelEntity ModelEntity  { get; set; }
        public virtual ICollection<ProductMGRefEntity> ProductMGRefEntity { get; set; }
        public virtual ICollection<OrderDetailsEntity> OrderDetailsEntities { get; set; }
        public virtual ICollection<WishListEntity> WishListEntities { get; set; }
        public virtual ICollection<QuantityReadyForSale> QuantityReadyForSales { get; set; }
     
       
    }
}
