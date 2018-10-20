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
    public class WishlistController : Controller
    {
        private IUnitOfWork db;
        public WishlistController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var wishList = db.rWishList.GetAll();
            return Json(wishList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var wishlistitem = db.rWishList.Get(id);
            return Json(wishlistitem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.rWishList.Remove(await db.rWishList.Get(id));
            db.Complete();
            return NoContent();
        }
        [HttpPost]
        public IActionResult PostCreate(WishListViewModel wvm)
        {
            if (ModelState.IsValid)
            {

                db.rWishList.Add(new Entity.Model.WishListEntity { fkProductID = wvm.ProductID, Caption = wvm.Caption, DTInserted = DateTime.Now, DTUpdated= DateTime.Now});
                db.Complete();
            }
            else
            {
                return BadRequest();
            }
            return Ok(wvm);
        }
        [HttpPut("{id}")]
        public IActionResult PutUpdate(WishListViewModel wvm, int id)
        {
            if (ModelState.IsValid)
            {
                var oldwishlist = db.rWishList.Get(id).Result;
                if (oldwishlist != null)
                {
                    oldwishlist.Caption = wvm.Caption;
                    oldwishlist.fkProductID = wvm.ProductID;
                    oldwishlist.DTInserted = oldwishlist.DTInserted;
                    oldwishlist.DTUpdated = wvm.DTUpdated;
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
            return Ok(wvm);
        }

    }
}