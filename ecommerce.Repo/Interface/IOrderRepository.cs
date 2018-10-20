using ecommerce.Entity.Model;
using ecommerce.ViewModel.DataViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ecommerce.Repo.Interface
{
    public interface IOrderRepository : IRepository<OrderEntity>
    {
        bool Delete(int id);
        bool AddAsync(OrderViewModel ovm);
        Task<OrderViewModel> FindByIdAsync(int id);
        IEnumerable<OrderViewModel> orderGetAll();
        Task<OrderViewModel> UpdateAsync(OrderViewModel ovm, int id);
    }
}
