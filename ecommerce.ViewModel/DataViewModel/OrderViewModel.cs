using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.ViewModel.DataViewModel
{
    public class OrderViewModel
    {
        public int ID { get; set; }

        public int fkOrderStatusID { get; set; }

        public string OrderIdentifer { get; set; }
        public bool IsFullPaid { get; set; }
        public bool IsLocked { get; set; }
        public DateTime DTOrderPlaced { get; set; }
        public DateTime DTOrderDelivered { get; set; }


        public int osID { get; set; }
        public string osCaption { get; set; }
        public string osOptionName { get; set; }
        public string osShortDetails { get; set; }
        public bool osIsActive { get; set; }


        public int odID { get; set; }
        public int odfkOrderID { get; set; }
        public int odfkProductID { get; set; }

        public double odUnitQuantity { get; set; }
        public double odPerUnitSellingPrice { get; set; }
        public string odItemFullInfo { get; set; }


    }
}
