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
    public class OrderRepository : Repository<OrderEntity>, IOrderRepository
    {
        #region main

      
        public OrderRepository(DataDbContext context) : base(context)
        {

        }
        public DataDbContext DataDbContext
        {
            get { return _context as DataDbContext; }
        }
        #endregion
        public bool AddAsync(OrderViewModel ovm)
        {
            if (ovm.DTOrderDelivered != null)
            {
                DataDbContext.OrderEntity.Add(new OrderEntity
                {
                    fkOrderStatusID = ovm.fkOrderStatusID,
                    DTOrderPlaced = ovm.DTOrderPlaced,
                    DTOrderDelivered = ovm.DTOrderDelivered,
                    IsFullPaid = ovm.IsFullPaid,
                    IsLocked = ovm.IsLocked,
                    OrderIdentifer = ovm.OrderIdentifer
                });
                DataDbContext.SaveChanges();
                ovm.ID = DataDbContext.OrderEntity.Max(o=>o.ID);
                if (ovm.ID > 0)
                {
                    DataDbContext.OrderDetailsEntity.Add(new OrderDetailsEntity
                    {
                        fkOrderID = ovm.ID,
                        ItemFullInfo = ovm.odItemFullInfo,
                        PerUnitSellingPrice = ovm.odPerUnitSellingPrice,
                        UnitQuantity = ovm.odUnitQuantity,
                        fkProductID = ovm.odfkProductID
                    });
                    DataDbContext.SaveChanges();
                   
                    ovm.odID = DataDbContext.OrderDetailsEntity.Max(orderDetailsId => orderDetailsId.ID);
                    //Quantity For sale Stock manage
                    if (ovm.odUnitQuantity > 0)
                    {
                      var productItem =  DataDbContext.ProductEntity.Find(ovm.odfkProductID);
                        var productStock = DataDbContext.QuantityReadyForSale.Find(productItem.ID);
                        if (productStock != null)
                        {
                            productStock.Quantity -= (int)ovm.odUnitQuantity;
                            DataDbContext.QuantityReadyForSale.Update(productStock);
                            DataDbContext.SaveChanges();
                        }

                    }
                }
                return true;
            }


            return false;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderViewModel> FindByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderViewModel> orderGetAll()
        {
            throw new NotImplementedException();
        }

        public Task<OrderViewModel> UpdateAsync(OrderViewModel ovm, int id)
        {
            throw new NotImplementedException();
        }
    }
}
