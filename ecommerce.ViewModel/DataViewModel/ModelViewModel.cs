using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ecommerce.ViewModel
{
    public class ModelViewModel
    {
        public int ID { get; set; }
        public int CatId { get; set; }
        [Required(ErrorMessage ="Model Name Required.")]
        public string ModelName { get; set; }
    }
}
