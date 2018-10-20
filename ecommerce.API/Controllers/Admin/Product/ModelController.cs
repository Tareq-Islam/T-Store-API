using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ecommerce.Repo;
using ecommerce.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelController : Controller
    {
        private IUnitOfWork db;
        public ModelController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var modelList = db.rModel.GetAll();
            return Json(modelList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var modelitem = db.rModel.Get(id);
            return Json(modelitem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.rModel.Remove(await db.rModel.Get(id));
            db.Complete();
            return NoContent();
        }
        [HttpPost]
        public IActionResult PostCreate(ModelViewModel mvm)
        {
            if (ModelState.IsValid)
            {

                db.rModel.Add(new Entity.Model.ModelEntity { ModelName = mvm.ModelName, fkCategoryID = mvm.CatId });
                db.Complete();
            }
            else
            {
                return BadRequest();
            }
            return Ok(mvm);
        }
        [HttpPut("{id}")]
        public IActionResult PutUpdate(ModelViewModel mvm, int id)
        {
            if (ModelState.IsValid)
            {
                var oldModel = db.rModel.Get(id).Result;
                if (oldModel != null)
                {
                    oldModel.ModelName = mvm.ModelName;
                    oldModel.fkCategoryID = mvm.CatId;
                    db.Complete();
                }
                else
                {
                    return Content("This value not exits.");
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok(mvm);
        }
    
    }
}