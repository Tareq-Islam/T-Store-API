using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ecommerce.ViewModel
{
    public class WishListViewModel
    {
        public int ID { get; set; }
        [Required]
        public int ProductID { get; set; }
        public string Caption { get; set; }
        public DateTime DTInserted { get; set; }
        public DateTime DTUpdated { get; set; }
    }
}
