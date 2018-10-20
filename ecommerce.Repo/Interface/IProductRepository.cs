using ecommerce.Entity.Model;
using ecommerce.ViewModel.DataViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.Interface
{
    public interface IProductRepository : IRepository<ProductEntity>
    {
        Task<ProductViewModel> FindByIdAsync(int id);
        void ConAdd(ProductViewModel pvm);
        IEnumerable<ProductViewModel> proGetAll();
        Task<ProductViewModel> UpdateAsync(ProductViewModel pvm, int id);
        bool Delete(int id);
    }
}
