using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMPMANAGE.Pages
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public RegisterModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {

            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Serializable]
        public class EmpVM
        {
            [Required]
            [EmailAddress]

            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm Passowrd")]
            [Compare("Password", ErrorMessage = "Password and confirmation don't match")]
            public string ConfirmPassword { get; set; }
        }


        [BindProperty]
        public EmpVM emp { get; set; }


        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPost()
        {
            var user = new IdentityUser
            {
                UserName = emp.Email,
                Email = emp.Email,
            };
            var result = await userManager.CreateAsync(user, emp.Password);
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToPage("/Index");
            }

            return Page();

        }
    }
}
