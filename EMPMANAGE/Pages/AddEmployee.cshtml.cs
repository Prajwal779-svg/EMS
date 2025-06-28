using EMPMANAGE.Application.EmployeeMng;
using EMPMANAGE.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMPMANAGE.Pages
{
    public class AddEmployeeModel : PageModel
    {
        private readonly IEmployeeManager em;

        public AddEmployeeModel(IEmployeeManager em)
        {
            this.em = em;
        }
        public void OnGet()
        {
        }
        [BindProperty]
        public CreateEmployee.Request request { get; set; }

        public async Task<IActionResult> OnPost()
        {
            await new CreateEmployee(em).Do(request);
            return RedirectToPage("/Index");
        }
    }
}
