using ecommerce.Entity;
using ecommerce.Entity.Model;
using ecommerce.Repo.Interface;
using ecommerce.ViewModel.DataViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.DAL
{
    public class ProductRepository : Repository<ProductEntity>, IProductRepository
    {
        public ProductRepository(DataDbContext context) : base(context)
        {

        }
        public DataDbContext DataDbContext
        {
            get { return _context as DataDbContext; }
        }
        public bool Delete(int id)
        {
            bool deleted = false;
            var product = FindByIdAsync(id).Result;
            if (product.ID > 0)
            {
                var ProductMGRefItem = DataDbContext.ProductMGRefEntity.Find(product.RFID);
                DataDbContext.ProductMGRefEntity.Remove(ProductMGRefItem);

                var QRFSItem = DataDbContext.QuantityReadyForSale.Find(product.qID);
                DataDbContext.QuantityReadyForSale.Remove(QRFSItem);

                DataDbContext.SaveChanges();
                deleted = true;
            }
            else if (deleted == true)
            {
                var pItem = DataDbContext.ProductEntity.Find(product.ID);
                DataDbContext.ProductEntity.Remove(pItem);
                DataDbContext.SaveChanges();
                return true;
            }
            return false;

            
        }
        public async Task<ProductViewModel> FindByIdAsync(int id)
        {
            //for async not use get
            await Get(id);
            //use 
            var data = from pc in (from p in DataDbContext.ProductEntity
                                   where p.ID == id
                                   join q in DataDbContext.QuantityReadyForSale on p.ID equals q.fkProductID
                                   join pm in DataDbContext.ProductMGRefEntity on
                                   p.ID equals pm.fkProductID
                                   join m in DataDbContext.MediaGalleryEntity on
                                   pm.fkMGID equals m.ID
                                   select new
                                   {
                                       //product property
                                       pID = p.ID,
                                       pName = p.Name,
                                       pDisplayOrder = p.DisplayOrder,
                                       pIsActive = p.IsActive,

                                       pPrice = p.Price,
                                      

                                       //Quantity property 
                                       qID = q.ID,
                                       qQuantity = q.Quantity,

                                       //Media Gallery property
                                       mID = m.ID,
                                       mFilePathOrLink = m.FilePathOrLink,


                                   })
                       group pc by new
                       {
                           pc.pID,
                           pc.qID,
                           pc.mID,
                           pc.pName,
                           pc.pDisplayOrder,
                           pc.pIsActive,
                           pc.pPrice,
                           pc.qQuantity,
                           pc.mFilePathOrLink,



                       } into g
                       select new
                       {
                           ID = g.Key.pID,
                           QRFSID = g.Key.qID,
                           MediaID = g.Key.mID,
                           Name = g.Key.pName,
                           DisplayOrder = g.Key.pDisplayOrder,
                           IsActive = g.Key.pIsActive,
                           Price = g.Key.pPrice,
                           Quantity = g.Key.qQuantity,
                           FilePathOrLink = g.Select(s => s.mFilePathOrLink)
                       };
            //for casting and add ViewModel
            ProductViewModel pData = new ProductViewModel();
            if (pData != null)
            {
                foreach (var item in data)
                {
                    pData.ID = item.ID;
                    pData.Name = item.Name;
                    pData.DisplayOrder = item.DisplayOrder;
                    pData.IsActive = item.IsActive;
                    pData.Price = item.Price;
                    pData.Quantity = item.Quantity;
                    pData.ImageUrl = item.FilePathOrLink;
                    pData.qID = item.QRFSID;
                    pData.MediaID = item.MediaID;
                  
                }
            }
            //for casting and add ViewModel



            return pData;
        }
        public void ConAdd(ProductViewModel pvm)
        {
            if (pvm.Price > 0)
            {
                DataDbContext.ProductEntity.AddAsync(new ProductEntity { Name = pvm.Name, Price = pvm.Price, BarCode = pvm.BarCode, Description = pvm.Description,
                    DisplayOrder = pvm.DisplayOrder, IsActive = pvm.IsActive, fkBrandMakerID = pvm.fkBrandMakerID, fkCategoryID = pvm.fkCategoryID, fkModelID = pvm.fkModelID,
                    IsCustomizable = pvm.IsCustomizable, IsHidden = pvm.IsHidden, IsParmanent = pvm.IsParmanent, PlaceOfOrgin = pvm.PlaceOfOrgin, ProductFeature = pvm.ProductFeature,
                    QRCode = pvm.QRCode, ReturnPolicy = pvm.ReturnPolicy, RFID = pvm.RFID, SKU = pvm.SKU, UPC = pvm.UPC, SellerService = pvm.SellerService, WarrentlyPolicy = pvm.WarrentlyPolicy
                });
                DataDbContext.SaveChanges();
                pvm.ID = DataDbContext.CategoryEntity.Max(p => p.ID);
            }
            else if (pvm.Quantity > 0)
            {
                DataDbContext.QuantityReadyForSale.AddAsync(new QuantityReadyForSale { fkProductID = pvm.fkProductID, Quantity = pvm.Quantity, DateUpdated = DateTime.Now,

                    DateInserted = DateTime.Now });
                DataDbContext.SaveChanges();
                pvm.qID = DataDbContext.QuantityReadyForSale.Max(q => q.ID);
            }
            else if (pvm.mFilePathOrLink != null)
            {
                DataDbContext.MediaGalleryEntity.AddAsync(new MediaGalleryEntity { Description = pvm.Description, FilePathOrLink = pvm.mFilePathOrLink, IsActive = pvm.IsActive, Caption = pvm.mCaption,
                    DisplayOrder = pvm.DisplayOrder, IsDefault = pvm.mIsDefault, IsHidden = pvm.IsHidden, IsParmanent = pvm.IsParmanent, Name = pvm.mName, ShortDetails = pvm.mShortDetails
                });
                DataDbContext.SaveChanges();
                pvm.MediaID = DataDbContext.MediaGalleryEntity.Max(m => m.ID);
            }

        }
        public IEnumerable<ProductViewModel> proGetAll()
        {
            var data = from pc in (from p in DataDbContext.ProductEntity                                  
                                   join q in DataDbContext.QuantityReadyForSale on p.ID equals q.fkProductID
                                   join pm in DataDbContext.ProductMGRefEntity on
                                   p.ID equals pm.fkProductID
                                   join m in DataDbContext.MediaGalleryEntity on
                                   pm.fkMGID equals m.ID
                                   select new
                                   {
                                       //product property
                                       pID = p.ID,
                                       pName = p.Name,
                                       pDisplayOrder = p.DisplayOrder,
                                       pIsActive = p.IsActive,

                                       pPrice = p.Price,

                                       //Quantity property                                 
                                       qQuantity = q.Quantity,

                                       //Media Gallery property

                                       mFilePathOrLink = m.FilePathOrLink,


                                   })
                       group pc by new
                       {
                           pc.pID,
                           pc.pName,
                           pc.pDisplayOrder,
                           pc.pIsActive,
                           pc.pPrice,
                           pc.qQuantity,
                           pc.mFilePathOrLink,



                       } into g
                       select new
                       {
                           ID = g.Key.pID,
                           Name = g.Key.pName,
                           DisplayOrder = g.Key.pDisplayOrder,
                           IsActive = g.Key.pIsActive,
                           Price = g.Key.pPrice,
                           Quantity = g.Key.qQuantity,
                           FilePathOrLink = g.Select(s => s.mFilePathOrLink)
                       };
            //for casting and add ViewModel
            List<ProductViewModel> DataList = new List<ProductViewModel>();
            if (data != null)
            {


                ProductViewModel obj = new ProductViewModel();


                foreach (var item in data)
                {
                    obj.ID = item.ID;
                    obj.Name = item.Name;
                    obj.DisplayOrder = item.DisplayOrder;
                    obj.IsActive = item.IsActive;
                    obj.Price = item.Price;
                    obj.Quantity = item.Quantity;
                    obj.ImageUrl = item.FilePathOrLink;

                    DataList.Add(obj);
                }
            }


            return DataList;
        }
        public async Task<ProductViewModel> UpdateAsync(ProductViewModel pvm, int id)
        {
            var oldData = await FindByIdAsync(pvm.ID);
            if (oldData.ID > 0)
            {
              var orginalData = await DataDbContext.ProductEntity.FindAsync(oldData.ID);
                orginalData.Name = pvm.Name;
                orginalData.BarCode = pvm.BarCode;
                orginalData.Description = pvm.Description;
                orginalData.DisplayOrder = pvm.DisplayOrder;
                orginalData.fkBrandMakerID = pvm.fkBrandMakerID;
                orginalData.fkCategoryID = pvm.fkCategoryID;
                orginalData.fkModelID = pvm.fkModelID;
                orginalData.IsActive = pvm.IsActive;
                orginalData.IsCustomizable = pvm.IsCustomizable;
                orginalData.IsHidden = pvm.IsHidden;
                orginalData.IsParmanent = pvm.IsParmanent;
                orginalData.PlaceOfOrgin = pvm.PlaceOfOrgin;
                orginalData.Price = pvm.Price;
                orginalData.ProductFeature = pvm.ProductFeature;
                orginalData.QRCode = pvm.QRCode;
                orginalData.ReturnPolicy = pvm.ReturnPolicy;
                orginalData.RFID = pvm.RFID;
                orginalData.SellerService = pvm.SellerService;
                orginalData.SKU = pvm.SKU;
                orginalData.UPC = pvm.UPC;
                orginalData.WarrentlyPolicy = pvm.WarrentlyPolicy;
                DataDbContext.SaveChanges();
            }
            else if(pvm.qID > 0)
            {
                var ogrData = await DataDbContext.QuantityReadyForSale.FindAsync(pvm.qID);
                ogrData.Quantity = pvm.Quantity;
                ogrData.fkProductID = pvm.fkProductID;
                ogrData.DateInserted = ogrData.DateInserted;
                ogrData.DateUpdated = pvm.DateUpdated;
                DataDbContext.SaveChanges();
            }
            else if (pvm.MediaID > 0)
            {
                var orgData = await DataDbContext.MediaGalleryEntity.FindAsync(pvm.MediaID);
                orgData.Caption = pvm.mCaption;
                orgData.Description = pvm.Description;
                orgData.FilePathOrLink = pvm.mFilePathOrLink;
                orgData.IsActive = pvm.IsActive;
                orgData.IsDefault = pvm.mIsDefault;
                orgData.DisplayOrder = pvm.mDisplayOrder;
                orgData.Name = pvm.Name;
                DataDbContext.SaveChanges();

            }
            

            return pvm;
        }

    }
}
