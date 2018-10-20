using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Repo;
using ecommerce.ViewModel.DataViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private IUnitOfWork db;
        public OrderStatusController(IUnitOfWork context)
        {
            db = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var orderstatausList = db.rOrderStatus.GetAll();
            return Ok(orderstatausList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orderstatusItem = db.rOrderStatus.Get(id);
            return Ok(orderstatusItem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id > 0)
            {
                db.rOrderStatus.Remove(await db.rOrderStatus.Get(id));
                db.Complete();
                return Ok(true);
            }
            else
            {
                return BadRequest("This ID not Valid.");
            }

        }
        [HttpPost]
        public IActionResult Post(OrderViewModel ovm)
        {

            if (ModelState.IsValid)
            {
                db.rOrderStatus.Add(new Entity.Model.OrderStatusEntity { Caption= ovm.osCaption, IsActive = ovm.osIsActive, OptionName=ovm.osOptionName, ShortDetails=ovm.osShortDetails  });
                db.Complete();
            }
            else
            {
                return BadRequest("This Data not Valid.");
            }

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(OrderViewModel ovm, int id)
        {
            if (ModelState.IsValid)
            {
                var orderstatusItem = await db.rOrderStatus.Get(id);

                if (orderstatusItem != null)
                {
                    orderstatusItem.IsActive = ovm.osIsActive;
                    orderstatusItem.OptionName = ovm.osOptionName;
                    orderstatusItem.ShortDetails = ovm.osShortDetails;
                    orderstatusItem.Caption = ovm.osCaption;
                    db.Complete();
                    return Ok(ovm);
                }

            }
            else
            {
                return BadRequest("This Data not Valid.");
            }
            return Ok(ovm);

        }
    }
}