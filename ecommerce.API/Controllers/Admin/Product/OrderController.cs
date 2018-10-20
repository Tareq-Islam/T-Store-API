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
    public class OrderController : ControllerBase
    {
        private IUnitOfWork db;
        public OrderController(IUnitOfWork context)
        {
            db = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var orderList = db.rOrder.orderGetAll();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var orderItem = db.rOrder.FindByIdAsync(id);
            return Ok(orderItem);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
              bool deleted = db.rOrder.Delete(id);
              return Ok(deleted);
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
              bool added =  db.rOrder.AddAsync(ovm);
                if (added == true)
                {
                    return Ok(ovm);
                }
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
                await db.rOrder.UpdateAsync(ovm, id);
                return Ok(true);
            }
            else
            {
                return BadRequest("This Data not Valid.");
            }
                      
        }
    }
}