using System.Linq;
using System.Threading.Tasks;
using ecommerce.Identity;
using ecommerce.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ecommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        public UserController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        //api/User
        [HttpGet]       
        public IActionResult Get()
        {
            var user = _userManager.Users.ToList();

            return Ok(user);

        }
        [HttpGet("{id}")]       
        public async Task<IActionResult> Get(string Id)
        {
            var model = await _userManager.FindByIdAsync(Id);
            return Ok(model);
        }

        [HttpPost]       
        public async Task<IActionResult> Create([FromBody]UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var newUser = new ApplicationUser { UserName = model.Email, Email = model.Email, FirstName = model.FirstName, LastName = model.LastName, PhoneNumber = model.PhoneNumber };
                var user = _userManager.CreateAsync(newUser, model.Password).Result;
                if (user.Succeeded)
                {
                    await _userManager.AddToRolesAsync(newUser, model.Roles);
                    return Ok();
                }

                return Ok();
            }


            return NoContent();
        }

        [HttpPut("{id}")]      
        public async Task<IActionResult> Edit(UserViewModel updateUser, string id)
        {
            var model = await _userManager.FindByIdAsync(updateUser.Id);
            if (model != null)
            {
              
               
                if (User.IsInRole("admin") == true)
                {
                    await _userManager.AddToRolesAsync(model, updateUser.Roles);     
                    
                }
                else
                {
                    model.UserName = updateUser.Email;
                    model.PhoneNumber = updateUser.PhoneNumber;
                    model.Email = updateUser.Email;
                    model.FirstName = updateUser.FirstName;
                    model.LastName = updateUser.LastName;
                    model.PasswordHash = updateUser.Password;
                }
               

                var Update = await _userManager.UpdateAsync(model);

                return Ok(updateUser);
            }

            return NoContent();
        }
        [HttpDelete("{Id}")]       
        public async Task<IActionResult> Delete(string Id)
        {
            if (Id != null)
            {
                var user = await _userManager.FindByIdAsync(Id);
                var delete = await _userManager.DeleteAsync(user);
                return Ok();
            }
            return Ok();
        }
    }
}