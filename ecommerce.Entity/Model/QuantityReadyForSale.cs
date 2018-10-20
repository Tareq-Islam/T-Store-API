using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class QuantityReadyForSale
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
      

        public int fkProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateUpdated { get; set; }
        
        [ForeignKey("fkProductID")]
        public virtual ProductEntity ProductEntity { get; set; }

    }
}
