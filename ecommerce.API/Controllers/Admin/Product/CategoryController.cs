using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Entity;
using ecommerce.Repo;
using ecommerce.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        //CategoryEntity, MediaGalleryEntity, CategoryMGRefEntity
        private IUnitOfWork db;       
        public CategoryController(IUnitOfWork context)
        {
            db = context;
            
        }
        [HttpGet]
        public IActionResult GetAll()
        {

            var cate = db.rCategory.CMGetAll();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //var singleItem = db.rCategory.FindByIdAsync(id);
            return Ok();
        }
        [HttpDelete("{childid,parentid}")]
        public IActionResult Delete(int childid=0, int parentid=0)
        {
            if (childid > 0 && parentid > 0)
            {
                db.rCategory.Delete(childid, parentid);
            }
            else
            {
                return BadRequest("This ID not Valid.");
            }


            return Ok(true);
        }
        [HttpPost]
        public IActionResult Post(CategoryViewModel cmvm)
        {
          
            if (ModelState.IsValid)
            {
                db.rCategory.ConAdd(cmvm);                
            }
            else
            {
                return BadRequest("This Data not Valid.");
            }

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(CategoryViewModel viewModel, int id)
        {
            if (ModelState.IsValid)
            {
                await db.rCategory.UpdateAsync(viewModel, id);
            }

            return Ok(true);
        }

    }
}