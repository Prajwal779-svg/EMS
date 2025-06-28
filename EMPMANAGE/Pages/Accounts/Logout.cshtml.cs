using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMPMANAGE.Pages.Accounts
{
    public class LogoutModel : PageModel
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<LogoutModel> _logger;

        // Proper constructor injection
        public LogoutModel(SignInManager<IdentityUser> signInManager,
                         ILogger<LogoutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPost( SignInManager<IdentityUser> signInManager)
        {
            try
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out");

                // Clear authentication cookies
                await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                return LocalRedirect("~/Login"); // More secure than RedirectToPage
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Logout failed");
                return StatusCode(500);
            }
        }
    }
}
