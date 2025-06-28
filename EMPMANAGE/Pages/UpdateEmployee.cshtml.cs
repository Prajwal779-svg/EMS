using EMPMANAGE.Application.EmployeeMng;
using EMPMANAGE.Domain.Infrastructure;
using EMPMANAGE.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMPMANAGE.Pages
{
    public class UpdateEmployeeModel : PageModel
    {
        private readonly IEmployeeManager em;

        public UpdateEmployeeModel(IEmployeeManager em)
        {
            this.em = em;
        }
        public async Task OnGet(int id)
        {
            var emp = await em.GetEmployeeByIdAsync(id);
            request = new UpdateEmployee.Request
            {
                Id = emp.Id,
                Name = emp.Name,
                Email = emp.Email,
                Department = emp.Department,
                Position = emp.Position,
                Salary = emp.Salary,
                HireDate = emp.HireDate
            };

        }
        [BindProperty]
        public UpdateEmployee.Request request { get; set; }

        public async Task<IActionResult> OnPost()
        {
            await new UpdateEmployee(em).Do(request);
            return RedirectToPage("/Index");
        }
        
    }
}
