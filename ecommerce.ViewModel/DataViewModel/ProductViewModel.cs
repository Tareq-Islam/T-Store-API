using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.ViewModel.DataViewModel
{
    public class ProductViewModel
    {
        public int ID { get; set; }
        public int MediaID { get; set; }
        public int qID { get; set; }
        public string Name { get; set; }
        public long DisplayOrder { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public bool IsHidden { get; set; }
        public bool IsParmanent { get; set; }
        public int fkCategoryID { get; set; }
        public int fkBrandMakerID { get; set; }
        public int fkModelID { get; set; }

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
        public string mCaption { get; set; }
        public string mFilePathOrLink { get; set; }
        public string mShortDetails { get; set; }
        public bool mIsDefault { get; set; }
        public bool mIsActive { get; set; }
        public bool mIsParmanent { get; set; }
        public bool mIsHidden { get; set; }
        public string mName { get; set; }

        public long mDisplayOrder { get; set; }
        public int fkProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateInserted { get; set; }
        public DateTime DateUpdated { get; set; }
        public IEnumerable<string> ImageUrl { get; set; }
    }
}
