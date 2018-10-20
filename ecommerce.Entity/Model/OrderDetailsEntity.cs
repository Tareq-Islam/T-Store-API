using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Entity.Model
{
    public class OrderDetailsEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int fkOrderID { get; set;}
        public int fkProductID { get; set; }
   
        public double UnitQuantity { get; set; }
        public double PerUnitSellingPrice { get; set; }
        public string ItemFullInfo { get; set; }
        [ForeignKey("fkOrderID")]
        public virtual OrderEntity OrderEntity { get; set; }
        [ForeignKey("fkProductID")]
        public virtual ProductEntity ProductEntity { get; set; }
      
    }
}