using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Entity.Model;
using ecommerce.Repo;
using ecommerce.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : Controller
    {
        private IUnitOfWork db;
        public BrandController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var brandList = db.rBrandMarker.GetAll();
            return Json(brandList);
        }
        //api/Brand/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var brandList = db.rBrandMarker.Get(id);
            return Json(brandList);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.rBrandMarker.Remove(await db.rBrandMarker.Get(id));
            db.Complete();
            return NoContent();
        }
        [HttpPost]
        public IActionResult PostCreate(BrandViewModel bvm)
        {
            if (ModelState.IsValid)
            {
              
               db.rBrandMarker.Add(new Entity.Model.BrandMarkerEntity { BrandName = bvm.BrandName, fkCategoryID = bvm.CatID });
               db.Complete();
            }
            else
            {
                return BadRequest();
            }
            return Ok(bvm);
        }
        [HttpPut("{id}")]
        public IActionResult PutUpdate(BrandViewModel bvm, int id)
        {
            if (ModelState.IsValid)
            {
                var oldBrand = db.rBrandMarker.Get(bvm.ID).Result;
                if (oldBrand !=null )
                {
                    oldBrand.BrandName = bvm.BrandName;
                    oldBrand.fkCategoryID = bvm.CatID;
                    db.Complete();
                }
                else
                {
                    return Content("This value not exits.");
                }
            }
            else
            {
              return  BadRequest();
            }
            return Ok(bvm);
        }
    }
}