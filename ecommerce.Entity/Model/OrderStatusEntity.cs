using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ecommerce.Entity.Model
{
    public class OrderStatusEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Caption { get; set; }
        public string OptionName { get; set; }
        public string ShortDetails { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<OrderEntity> OrderEntities { get; set; }
    }
}
