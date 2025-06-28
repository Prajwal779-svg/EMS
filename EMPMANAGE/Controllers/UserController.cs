using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EMPMANAGE.Controllers
{

    [Route("[Controller]")]
    public class UserController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;


        public UserController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToPage("/Index");
        }
    }
}
