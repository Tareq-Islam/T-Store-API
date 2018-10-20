using ecommerce.Entity.Model;
using ecommerce.Repo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Repo
{
    public interface IUnitOfWork : IDisposable
    {
        int Complete();
        //add repository with Entity
        OrderRepository rOrder { get; }
        Repository<OrderStatusEntity> rOrderStatus { get; }
        CategoryRepository rCategory { get; }
        SubCategoryRepository rSubCategory { get; }
        ProductRepository rProduct { get; }
        Repository<SubCategoryMGRefEntity> rSubCategoryMGRef { get; }
        MediaGalleryRepository rMediaGallery { get; }
        Repository<BrandMarkerEntity> rBrandMarker { get; }
        Repository<ModelEntity> rModel { get; }
        Repository<WishListEntity> rWishList { get; }        
        
    }
}
