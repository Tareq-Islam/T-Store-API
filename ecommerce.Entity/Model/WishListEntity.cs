using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace ecommerce.Entity.Model
{
    public class WishListEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int fkUserID { get; set; }
        public int fkProductID { get; set; }
        public string Caption { get; set; }
        public DateTime DTInserted { get; set; }
        public DateTime DTUpdated { get; set; }
        [ForeignKey("fkProductID")]
        public virtual ProductEntity ProductEntity { get; set; }
    }
}
