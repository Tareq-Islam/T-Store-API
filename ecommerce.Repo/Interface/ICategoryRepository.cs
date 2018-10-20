using ecommerce.Entity.Model;
using ecommerce.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.Interface
{
    public interface ICategoryRepository : IRepository<CategoryEntity>
    {
        void Delete(int scId, int cId);
        void ConAdd(CategoryViewModel cvm);
        Task<CategoryViewModel> FindByIdAsync(int id);
        IEnumerable<CategoryViewModel> CMGetAll();
        Task<CategoryViewModel> UpdateAsync(CategoryViewModel cvm, int id);
    }
}
