using ecommerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {
        private RoleManager<IdentityRole> _roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        // GET: api/Role
        [HttpGet]       
        public IActionResult Get()
        {
            var role = _roleManager.Roles.ToList();
            return Ok(role);
        }

        // GET: api/Role/details/5
        [HttpGet("{id}")]
       
        public async Task<IActionResult> Get(string id)
        {
            var model = await _roleManager.FindByIdAsync(id);
            return Ok(model);
        }

        // POST: api/Role
        [HttpPost]       
        public async Task<IActionResult> Post([FromBody] RoleViewModel rvm)
        {
            if (rvm.Name != null)
            {
                var role = await _roleManager.CreateAsync(new IdentityRole { Name = rvm.Name });
                return Ok();
            }
           

            return Ok();
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]        
        public async Task<IActionResult> Put(string id, [FromBody] RoleViewModel rvm)
        {
            var oldRole = await _roleManager.FindByIdAsync(rvm.Id);
            oldRole.Name = rvm.Name;

            if (oldRole != null)
            {
                var Update = await _roleManager.UpdateAsync(oldRole);
                return Ok();
            }

            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]      
        public async Task<IActionResult> Delete(string id)
        {
            if (id != null)
            {
                var role = await _roleManager.FindByIdAsync(id);
                var delete = await _roleManager.DeleteAsync(role);
                return Ok();
            }
            return NoContent();
        }
    }
}
