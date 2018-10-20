using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Repo;
using ecommerce.ViewModel.DataViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IUnitOfWork db;
        public ProductController(IUnitOfWork context)
        {
            db = context;

        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var productList = db.rProduct.proGetAll();

            return Ok(productList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
          var productItem = await db.rProduct.FindByIdAsync(id);
            return Ok(productItem);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           bool deleted = db.rProduct.Delete(id);
            return Ok(deleted);
        }
        [HttpPost]
        public IActionResult Post(ProductViewModel pvm)
        {
            db.rProduct.ConAdd(pvm);          
            return Ok(true);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(ProductViewModel pvm, int id)
        {
           var update = await db.rProduct.UpdateAsync(pvm, id);
            return Ok(pvm);
        }
    }
}