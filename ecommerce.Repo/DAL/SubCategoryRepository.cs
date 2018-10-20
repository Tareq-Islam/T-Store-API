using ecommerce.Entity;
using ecommerce.Entity.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.DAL
{
    public class SubCategoryRepository 
    {
//        public SubCategoryRepository(DataDbContext context) : base(context)
//        {

//        }
//        public DataDbContext DataDbContext
//        {
//            get { return _context as DataDbContext; }
//        }


//        public int MaxId()
//        {
//            return DataDbContext.CategoryEntity.Max(m => m.ID);
//        }
//        public async Task<SubCategoryViewModel> FindByIdAsync(int id)
//        {
//            for async not use get
//            await Get(id);
//            use
//            var data = from pc in (from c in DataDbContext.subCategoryEntities
//                                   where c.ID == id
//                                   join cm in DataDbContext.SubCategoryMGRefEntity on
//                                   c.ID equals cm.fkSubCatID
//                                   join m in DataDbContext.MediaGalleryEntity on
//                                   cm.fkMGID equals m.ID
//                                   select new
//                                   {
//                                       category select property
//                                       cID = c.ID,
//                                       cName = c.Name,
//                                       cDisplayOrder = c.DisplayOrder,
//                                       cDescription = c.Description,
//                                       cVisiable = c.Visiable,
//                                       cIsParmanent = c.IsParmanent,
//                                       cIsHidden = c.IsHidden,
//                                       cIsActive = c.IsActive,
//                                       CategoryRef Table ID
//                                       cmRefID = cm.ID,

//                                       media select property
//                                       mID = m.ID,
//                                       mName = m.Name,
//                                       mShortDetails = m.ShortDetails,
//                                       mDisplayOrder = m.DisplayOrder,
//                                       mDescription = m.Description,
//                                       mIsParmanent = m.IsParmanent,
//                                       mIsHidden = m.IsHidden,
//                                       mIsActive = m.IsActive,
//                                       mCaption = m.Caption,
//                                       mFilePathOrLink = m.FilePathOrLink,
//                                       mIsDefault = m.IsDefault,
//                                   })
//                       group pc by new
//                       {
//                           pc.cID,
//                           pc.cName,
//                           pc.cDisplayOrder,
//                           pc.cDescription,
//                           pc.cVisiable,
//                           pc.cIsParmanent,
//                           pc.cIsHidden,
//                           pc.cIsActive,
//                           pc.cmRefID,

//                           pc.mID,
//                           pc.mName,
//                           pc.mShortDetails,
//                           pc.mDisplayOrder,
//                           pc.mDescription,
//                           pc.mIsParmanent,
//                           pc.mIsHidden,
//                           pc.mIsActive,
//                           pc.mCaption,
//                           pc.mFilePathOrLink,
//                           pc.mIsDefault,

//                       }
//    into g
//                       select new
//                       {
//                           ID = g.Key.cID,
//                           Name = g.Key.cName,
//                           DisplayOrder = g.Key.cDisplayOrder,
//                           IsActive = g.Key.cIsActive,
//                           Description = g.Key.cDescription,
//                           Visiable = g.Key.cVisiable,
//                           IsParmanent = g.Key.cIsParmanent,
//                           IsHidden = g.Key.cIsHidden,
//                           CategorymRefID = g.Key.cmRefID,
//                           ImageUrl = g.Select(c => c.mFilePathOrLink),
//                           MediaName = g.Key.mName,
//                           MediaShortDetails = g.Key.mShortDetails,
//                           MediaDisplayOrder = g.Key.mDisplayOrder,
//                           MediaID = g.Key.mID,
//                           MediaIsParmanent = g.Key.mIsParmanent,
//                           MediaIsActive = g.Key.mIsActive,
//                           MediaCaption = g.Key.mCaption,
//                           MediaIsDefault = g.Key.mIsDefault
//};

//            for casting and add ViewModel
//            SubCategoryViewModel cvm = new SubCategoryViewModel();
//            if (data != null)
//            {

//                foreach (var item in data)
//                {
//                    cvm.SubCategoryID = item.ID;
//                    cvm.MediaID = item.MediaID;
//                    cvm.SubCategoryMGRefID = item.CategorymRefID;
//                    cvm.SubCatName = item.Name;
//                    cvm.DisplayOrder = item.DisplayOrder;
//                    cvm.IsActive = item.IsActive;
//                    cvm.Description = item.Description;
//                    cvm.Visiable = item.Visiable;
//                    cvm.IsParmanent = item.IsParmanent;
//                    cvm.IsHidden = item.IsHidden;
//                    cvm.ImageUrl = item.ImageUrl;
//                    cvm.MediaName = item.MediaName;
//                    cvm.ShortDetails = item.MediaShortDetails;
//                    cvm.mDisplayOrder = item.MediaDisplayOrder;

//                    cvm.mIsParmanent = item.MediaIsParmanent;
//                    cvm.mIsActive = item.MediaIsActive;
//                    cvm.Caption = item.MediaCaption;
//                    cvm.IsDefault = item.MediaIsDefault;



//                }
//            }


//            return cvm;
//        }

//        public IEnumerable<SubCategoryViewModel> CMGetAll()
//{

//    var data = from pc in (from c in DataDbContext.subCategoryEntities
//                           join cm in DataDbContext.SubCategoryMGRefEntity on
//                           c.ID equals cm.fkSubCatID
//                           join m in DataDbContext.MediaGalleryEntity on
//                           cm.fkMGID equals m.ID
//                           select new
//                           {
//                               category select property
//                                       cID = c.ID,
//                               cName = c.Name,
//                               cDisplayOrder = c.DisplayOrder,
//                               cDescription = c.Description,
//                               cVisiable = c.Visiable,
//                               cIsParmanent = c.IsParmanent,
//                               cIsHidden = c.IsHidden,
//                               cIsActive = c.IsActive,

//                               media select property
//                                       mID = m.ID,
//                               mName = m.Name,
//                               mShortDetails = m.ShortDetails,
//                               mDisplayOrder = m.DisplayOrder,
//                               mDescription = m.Description,
//                               mIsParmanent = m.IsParmanent,
//                               mIsHidden = m.IsHidden,
//                               mIsActive = m.IsActive,
//                               mCaption = m.Caption,
//                               mFilePathOrLink = m.FilePathOrLink,
//                               mIsDefault = m.IsDefault,
//                           })
//               group pc by new
//               {
//                   pc.cID,
//                   pc.cName,
//                   pc.cDisplayOrder,
//                   pc.cIsActive,
//                   pc.mFilePathOrLink
//               }
//                      into g
//               select new
//               {
//                   ID = g.Key.cID,
//                   Name = g.Key.cName,
//                   DisplayOrder = g.Key.cDisplayOrder,
//                   IsActive = g.Key.cIsActive,
//                   ImageUrl = g.Select(c => c.mFilePathOrLink)
//               };

//    for casting and add ViewModel

//    List < SubCategoryViewModel > DataList = new List<SubCategoryViewModel>();
//    if (data != null)
//    {


//        SubCategoryViewModel obj = new SubCategoryViewModel();


//        foreach (var item in data)
//        {
//            obj.SubCategoryID = item.ID;
//            obj.SubCatName = item.Name;
//            obj.DisplayOrder = item.DisplayOrder;
//            obj.IsActive = item.IsActive;
//            obj.ImageUrl = item.ImageUrl;

//            DataList.Add(obj);
//        }
//    }


//    return DataList;

//}

//public async Task<SubCategoryViewModel> UpdateAsync(SubCategoryViewModel cvm, int id)
//{
//    var oldData = await FindByIdAsync(id);
//    if (oldData != null)
//    {

//        oldData.SubCatName = cvm.SubCatName;
//        oldData.DisplayOrder = cvm.DisplayOrder;
//        oldData.IsActive = cvm.IsActive;
//        oldData.Description = cvm.Description;
//        oldData.Visiable = cvm.Visiable;
//        oldData.IsParmanent = cvm.IsParmanent;
//        oldData.IsHidden = cvm.IsHidden;
//        oldData.ImageUrl = cvm.ImageUrl;
//        oldData.MediaName = cvm.MediaName;
//        oldData.ShortDetails = cvm.ShortDetails;
//        oldData.mDisplayOrder = cvm.mDisplayOrder;
//        oldData.mIsParmanent = cvm.mIsParmanent;
//        oldData.mIsActive = cvm.mIsActive;
//        oldData.Caption = cvm.Caption;
//        oldData.IsDefault = cvm.IsDefault;
//        DataDbContext.SaveChanges();
//    }

//    return cvm;
//}

    }
}
