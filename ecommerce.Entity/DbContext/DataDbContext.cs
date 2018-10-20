using ecommerce.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ecommerce.Entity
{
    public class DataDbContext : DbContext
    {
       
            public DataDbContext(DbContextOptions<DataDbContext> Options) : base(Options) { }

            // All DbSet...
            public DbSet<ProductEntity> ProductEntity { get; set; }
            public DbSet<CategoryEntity> CategoryEntity { get; set; }
            public DbSet<BrandMarkerEntity> BrandMarkerEntity { get; set; }
         
            public DbSet<MediaGalleryEntity> MediaGalleryEntity { get; set; }
         
            public DbSet<SubCategoryEntity> subCategoryEntities { get; set; }
            public DbSet<SubCategoryMGRefEntity> SubCategoryMGRefEntity { get; set; }
            public DbSet<ModelEntity> ModelEntity { get; set; }
          
            public DbSet<OrderDetailsEntity> OrderDetailsEntity { get; set; }
            public DbSet<OrderEntity> OrderEntity { get; set; }         
            public DbSet<OrderStatusEntity> OrderStatusEntity { get; set; }
            public DbSet<ProductMGRefEntity> ProductMGRefEntity { get; set; }
            public DbSet<QuantityReadyForSale> QuantityReadyForSale { get; set; }
            public DbSet<WishListEntity> WishListEntity { get; set; }
          
    }
}
