using ecommerce.Entity;
using ecommerce.Entity.Model;
using ecommerce.Repo.Interface;
using ecommerce.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.Repo.DAL
{
    public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
    {

        public CategoryRepository(DataDbContext context) : base(context)
        {

        }
        public DataDbContext DataDbContext
        {
            get { return _context as DataDbContext; }
        }
        public void Delete(int scId=0, int cId=0)
        {
            
            if (scId > 0)
            {
                //sub category item delete
               var subItem = DataDbContext.subCategoryEntities.Find(scId);
                DataDbContext.subCategoryEntities.Remove(subItem);
                DataDbContext.SaveChanges();
                //
            }
            else if(cId > 0)
            {
              
              var categoryItem = FindByIdAsync(cId);               

            }
        }

        public void ConAdd(CategoryViewModel cvm)
        {
            if (cvm.IsParent == true)
            {
                DataDbContext.CategoryEntity.Add(new CategoryEntity {
                        Name = cvm.cName, Description =cvm.cDescription, DisplayOrder = cvm.cDisplayOrder, IsActive = cvm.cIsActive,
                       IsHidden = cvm.cIsHidden, IsParmanent = cvm.cIsParmanent, Visiable = cvm.cVisiable
                    });
                DataDbContext.SaveChanges();
                cvm.cID = DataDbContext.CategoryEntity.Max(m => m.ID);
            }
            else if (cvm.IsParent == false)
            {
               
                DataDbContext.subCategoryEntities.Add(new SubCategoryEntity {
                     Name = cvm.scName, Visiable = cvm.scVisiable, IsParmanent = cvm.scIsParmanent, Description = cvm.scDescription,
                      DisplayOrder = cvm.scDisplayOrder, IsActive = cvm.scIsActive, fkCategoryID = cvm.scfkCategoryId, IsHidden = cvm.scIsHidden

                });
                DataDbContext.MediaGalleryEntity.Add(new MediaGalleryEntity {
                    Name = cvm.mName, IsHidden = cvm.mIsHidden, Caption = cvm.mCaption, Description = cvm.mShortDetails, ShortDetails = cvm.mShortDetails, DisplayOrder=cvm.mDisplayOrder,
                   FilePathOrLink = cvm.mFilePathOrLink, IsActive = cvm.mIsActive, IsDefault = cvm.mIsDefault, IsParmanent = cvm.mIsParmanent

                });
                DataDbContext.SaveChanges();
                cvm.mID = DataDbContext.MediaGalleryEntity.Max(m => m.ID);
                cvm.scID = DataDbContext.subCategoryEntities.Max(m => m.ID);
                if (cvm.mID > 0 && cvm.scID > 0) 
                {
                    DataDbContext.SubCategoryMGRefEntity.Add(new SubCategoryMGRefEntity { fkSubCategoryID = cvm.scID, fkMGID = cvm.mID });
                    DataDbContext.SaveChanges();
                    cvm.SubCategoryMGRefID = DataDbContext.SubCategoryMGRefEntity.Max(m => m.ID);
                }
            }
        }
        public async Task<CategoryViewModel> FindByIdAsync(int id)
        {
            //for async not use get
            await Get(id);
            //use 
            var data = from pc in (from c in DataDbContext.CategoryEntity
                                   where c.ID == id
                                   join sc in DataDbContext.subCategoryEntities on c.ID equals sc.fkCategoryID
                                   join cm in DataDbContext.SubCategoryMGRefEntity on
                                   c.ID equals cm.fkSubCategoryID
                                   join m in DataDbContext.MediaGalleryEntity on
                                   cm.fkMGID equals m.ID
                                   select new
                                   {
                                       //category select property
                                       cID = c.ID,
                                       cName = c.Name,
                                       cDisplayOrder = c.DisplayOrder,
                                       cDescription = c.Description,
                                       cVisiable = c.Visiable,
                                       cIsParmanent = c.IsParmanent,
                                       cIsHidden = c.IsHidden,
                                       cIsActive = c.IsActive,
                                       //sub category select property
                                      scID = sc.ID,
                                      scName = sc.Name,
                                      scIsActive = sc.IsActive,
                                      scIsHidden = sc.IsHidden,
                                      scIsParmanent = sc.IsParmanent,
                                      scVisiable = sc.Visiable,
                                      scDisplayOrder = sc.DisplayOrder,
                                      scDescription = sc.Description,

                                       //media select property
                                       mID = m.ID,
                                       mName = m.Name,
                                       mShortDetails = m.ShortDetails,
                                       mDisplayOrder = m.DisplayOrder,
                                       mDescription = m.Description,
                                       mIsParmanent = m.IsParmanent,
                                       mIsHidden = m.IsHidden,
                                       mIsActive = m.IsActive,
                                       mCaption = m.Caption,
                                       mFilePathOrLink = m.FilePathOrLink,
                                       mIsDefault = m.IsDefault,
                                   })
                        group pc by new {
                            pc.cID, pc.cName,pc.cDisplayOrder,pc.cDescription,pc.cVisiable,pc.cIsParmanent,pc.cIsHidden,pc.cIsActive,
                            pc.scID, pc.scName,pc.scDisplayOrder, pc.scDescription, pc.scVisiable, pc.scIsParmanent, pc.scIsHidden, pc.scIsActive,
                            pc.mID,pc.mName,pc.mShortDetails, pc.mDisplayOrder,pc.mDescription,pc.mIsParmanent,pc.mIsHidden,pc.mIsActive,pc.mCaption,pc.mFilePathOrLink,pc.mIsDefault,
                        } into g
                       select new
                       {
                           ID = g.Key.cID,
                           Name = g.Key.cName,
                           DisplayOrder = g.Key.cDisplayOrder,
                           Description = g.Key.cDescription,
                           Visiable = g.Key.cVisiable,
                           IsParmanent = g.Key.cIsParmanent,
                           IsHidden = g.Key.cIsHidden,
                           IsActive = g.Key.cIsActive,

                           scID = g.Select(sc=>sc.scID),
                           scName = g.Select(sc=>sc.scName),
                           scIsActive = g.Select(sc=>sc.scIsActive),
                           scIsHidden = g.Select(sc=>sc.scIsHidden),
                           scIsParmanent = g.Select(sc=>sc.scIsParmanent),
                           scVisiable = g.Select(sc=>sc.scVisiable),
                           scDisplayOrder = g.Select(sc=>sc.scDisplayOrder),
                           scDescription = g.Select(sc=>sc.scDescription),

                           //media select property
                           mID =            g.Select(m=>m.mID),
                           mName =          g.Select(m=>m.mName),
                           mShortDetails =  g.Select(m=>m.mShortDetails),
                           mDisplayOrder =  g.Select(m=>m.mDisplayOrder),
                           mDescription =   g.Select(m=>m.mDescription),
                           mIsParmanent =   g.Select(m=>m.mIsParmanent),
                           mIsHidden =      g.Select(m=>m.mIsHidden),
                           mIsActive =      g.Select(m=>m.mIsActive),
                           mCaption =       g.Select(m=>m.mCaption),
                           mFilePathOrLink = g.Select(m=>m.mFilePathOrLink),
                           mIsDefault =      g.Select(m=>m.mIsDefault),



                       };          

            //for casting and add ViewModel
            CategoryViewModel cvm = new CategoryViewModel();
            if (data != null)
            {

                foreach (var item in data)
                {
                    cvm.cID = item.ID;
                    cvm.cName = item.Name;
                    cvm.cDisplayOrder = item.DisplayOrder;
                    cvm.cIsActive = item.IsActive;
                    cvm.cDescription = item.Description;
                    cvm.cVisiable = item.Visiable;
                    cvm.cIsParmanent = item.IsParmanent;
                    cvm.cIsHidden = item.IsHidden;

                    

                }
            }


            return cvm;
        }

        public IEnumerable<CategoryViewModel> CMGetAll()
        {

            var data = from pc in (from c in DataDbContext.CategoryEntity
                                   join sc in DataDbContext.subCategoryEntities on c.ID equals sc.fkCategoryID
                                   join cm in DataDbContext.SubCategoryMGRefEntity on
                                   c.ID equals cm.fkSubCategoryID
                                   join m in DataDbContext.MediaGalleryEntity on
                                   cm.fkMGID equals m.ID
                                   select new
                                   {
                                       //Category Table
                                       cID = c.ID,
                                       cName = c.Name,
                                       cDisplayOrder = c.DisplayOrder,
                                       cIsActive = c.IsActive,
                                       //Sub Category Table
                                       scName = sc.Name,
                                       scID = sc.ID,
                                       scIsActive = sc.IsActive,

                                       //media select property
                                       mID = m.ID,
                                       mName = m.Name,
                                       mIsActive = m.IsActive,
                                       mFilePathOrLink = m.FilePathOrLink,
                                       mIsDefault = m.IsDefault,
                                   })
                                group pc by new { pc.cID, pc.cName, pc.cIsActive, pc.cDisplayOrder, pc.mFilePathOrLink, pc.mID, pc.scID, pc.scIsActive, pc.scName, pc.mIsDefault, pc.mIsActive, pc.mName } into g
                                select new { CategoryID = g.Key.cID,
                                CategoryName = g.Key.cName,
                                IsActive = g.Key.cIsActive,
                                DisplayOrer = g.Key.cDisplayOrder,
                                SubName = g.Select(n => n.scName).ToList(),
                                FilePathOrLink = g.Select(c => c.mFilePathOrLink).ToList() };
            //for casting and add ViewModel
            List<CategoryViewModel> DataList = new List<CategoryViewModel>();
            if (data != null)
            {


                CategoryViewModel obj = new CategoryViewModel();


                foreach (var item in data)
                {
                    obj.cID = item.CategoryID;
                    obj.cName = item.CategoryName;
                    obj.cIsActive = item.IsActive;
                    obj.cDisplayOrder = item.DisplayOrer;
                    obj.ImageUrl = item.FilePathOrLink;
                    obj.SubName = item.SubName;

                    DataList.Add(obj);
                }
            }


            return DataList;

        }

        public async Task<CategoryViewModel> UpdateAsync(CategoryViewModel cvm, int id)
        {
            var oldData = await FindByIdAsync(id);
            if (oldData != null)
            {

                //oldData.CatName = cvm.CatName;
                //oldData.DisplayOrder = cvm.DisplayOrder;
                //oldData.IsActive = cvm.IsActive;
                //oldData.Description = cvm.Description;
                //oldData.Visiable = cvm.Visiable;
                //oldData.IsParmanent = cvm.IsParmanent;
                //oldData.IsHidden = cvm.IsHidden;
                //oldData.ImageUrl = cvm.ImageUrl;
                //oldData.MediaName = cvm.MediaName;
                //oldData.ShortDetails = cvm.ShortDetails;
                //oldData.mDisplayOrder = cvm.mDisplayOrder;
                //oldData.mIsParmanent = cvm.mIsParmanent;
                //oldData.mIsActive = cvm.mIsActive;
                //oldData.Caption = cvm.Caption;
                //oldData.IsDefault = cvm.IsDefault;
                //DataDbContext.SaveChanges();
            }

            return cvm;
        }

        #region TestPurpos
        //    from c in DataDbContext.CategoryEntity
        //                   join cmre in DataDbContext.CategoryMGRefEntity on c.ID equals cmre.fkCategoryID into cmj
        //                   from cm in cmj.DefaultIfEmpty()
        //                   from m in DataDbContext.MediaGalleryEntity.Where(m => cm != null && m.ID == cm.fkMGID).DefaultIfEmpty()

        //                   select(new CategoryViewModel
        //                   {
        //                       CatName = c.Name, MediaName = m.Name


        //});

        #endregion
    }
}
