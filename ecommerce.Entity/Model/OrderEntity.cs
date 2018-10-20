using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Entity.Model
{
    public class OrderEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
      
        public int fkOrderStatusID { get; set; }
      
        public string OrderIdentifer { get; set; }
        public bool IsFullPaid { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DTOrderPlaced { get; set; }
        public DateTime DTOrderDelivered { get; set; }
       
        [ForeignKey("fkOrderStatusID")]
        public virtual OrderStatusEntity OrderStatusEntity { get; set; }
    }
}
