using ecommerce.Entity.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.Interface
{
    interface ISubCategoryRepository : IRepository<SubCategoryEntity>
    {
        int MaxId();
        Task<SubCategoryEntity> FindByIdAsync(int id);
        IEnumerable<SubCategoryEntity> CMGetAll();
        Task<SubCategoryEntity> UpdateAsync(SubCategoryEntity cvm, int id);
    }
}
