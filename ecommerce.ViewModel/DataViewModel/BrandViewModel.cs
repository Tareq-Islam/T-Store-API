using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ecommerce.ViewModel
{
    public class BrandViewModel
    {
        public int ID { get; set; }
        
        public int CatID { get; set; }
        public string CatName { get; set; }
        [Required(ErrorMessage ="Brand Name Required.")]
        public string BrandName { get; set; }
    }
}
