using ecommerce.Entity;
using ecommerce.Entity.Model;
using ecommerce.Repo.DAL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private DataDbContext _context;
        #region ConstructorWithDI
        public UnitOfWork(DataDbContext context)
        {
            this._context = context;
        }
        #endregion


        #region declearPropertyPrivate
        private OrderRepository orders;
        private Repository<OrderStatusEntity> orderstatus;
        private ProductRepository products;
        private CategoryRepository categories;
        private SubCategoryRepository subcategories;
        private Repository<SubCategoryMGRefEntity> subcategorymgref;
        private Repository<BrandMarkerEntity> brands;
        private Repository<ModelEntity> models;
        private Repository<WishListEntity> wishlists;
        private MediaGalleryRepository mediaGallery;

        #endregion



        #region declearPropertyretrun
        public Repository<OrderStatusEntity> rOrderStatus
        {
            get
            {
                if (this.orderstatus == null)
                {
                    this.orderstatus = new Repository<OrderStatusEntity>(_context);
                }
                return orderstatus;
            }
        }
        public OrderRepository rOrder
        {
            get
            {
                if (this.orders == null)
                {
                    this.orders = new OrderRepository(_context);
                }
                return orders;
            }
        }
        public ProductRepository rProduct
        {
            get
            {
                if (this.products == null)
                {
                    this.products = new ProductRepository(_context);
                }
                return products;
            }
        }
        public Repository<SubCategoryMGRefEntity> rSubCategoryMGRef
        {
            get
            {
                if (this.subcategorymgref == null)
                {
                    this.subcategorymgref = new Repository<SubCategoryMGRefEntity>(_context);
                }
                return subcategorymgref;
            }
        }
        public SubCategoryRepository rSubCategory
        {
            get
            {
                if (this.subcategories == null)
                {
                    this.subcategories = new SubCategoryRepository();
                }
                return subcategories;
            }
        }


        public MediaGalleryRepository rMediaGallery
        {
            get
            {
                if (this.mediaGallery == null)
                {
                    this.mediaGallery = new MediaGalleryRepository(_context);
                }
                return mediaGallery; }
        }

        public Repository<WishListEntity> rWishList
        {
            get
            {
                if (this.wishlists == null)
                {
                    this.wishlists = new Repository<WishListEntity>(_context);
                }
                return wishlists;
            }
        }
        public Repository<ModelEntity> rModel
        {
            get
            {
                if (this.models == null)
                {
                    this.models = new Repository<ModelEntity>(_context);
                }
                return models;
            }
        }
        public Repository<BrandMarkerEntity> rBrandMarker
        {
            get
            {
                if (this.brands == null)
                {
                    this.brands = new Repository<BrandMarkerEntity>(_context);
                }
                return brands;
            }
        }

        public CategoryRepository rCategory
        {
            get
            {
                if (this.categories == null)
                {
                    this.categories = new CategoryRepository(_context);
                }
                return categories;
            }
        }

        #endregion



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
