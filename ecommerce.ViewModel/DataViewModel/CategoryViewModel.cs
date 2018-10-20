using ecommerce.Entity.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ecommerce.ViewModel
{
    public class CategoryViewModel
    {
        public int cID { get; set; }
        public string cName { get; set; }
        public long cDisplayOrder { get; set; }
        public string cDescription { get; set; }
        public bool cIsActive { get; set; }
        public bool cIsHidden { get; set; }
        public bool cIsParmanent { get; set; }
        public bool cVisiable { get; set; }
        //check parent
        public bool IsParent { get; set; }

        public int scID { get; set; }
        public int mID { get; set; }
        [Required]
        public string scName { get; set; }
        [Required]
        public int scfkCategoryId { get; set; }
        public string mName { get; set; }
        public long scDisplayOrder { get; set; }
        public string scDescription { get; set; }
        public bool scIsActive { get; set; }
        public bool scIsHidden { get; set; }
        public bool scIsParmanent { get; set; }
        public bool scVisiable { get; set; }
        public string mCaption { get; set; }
        public string mFilePathOrLink { get; set; }
        public string mShortDetails { get; set; }
        public bool mIsDefault { get; set; }       
        public bool mIsActive { get; set; }
        public bool mIsParmanent { get; set; }
        public bool mIsHidden { get; set; }

        public long mDisplayOrder { get; set; }

        public int SubCategoryMGRefID { get; set; }
        public IEnumerable<string> ImageUrl { get; set; }
        public IEnumerable<string> SubName { get; set; }
        public IEnumerable<MediaGalleryEntity> MediaList { get; set; }
        public IEnumerable<SubCategoryEntity> SubCategoryList { get; set; }


    }  
}      
               
       