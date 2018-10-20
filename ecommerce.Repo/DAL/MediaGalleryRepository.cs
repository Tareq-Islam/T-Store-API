using ecommerce.Entity;
using ecommerce.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ecommerce.Repo.DAL
{
    public class MediaGalleryRepository : Repository<MediaGalleryEntity>
    {
        public MediaGalleryRepository(DataDbContext context) : base(context)
        {

        }
        public DataDbContext DataDbContext
        {
            get { return _context as DataDbContext; }
        }

        public int MaxId()
        {
            return DataDbContext.MediaGalleryEntity.Max(m => m.ID);
        }


    }
}
