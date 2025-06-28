using EMPMANAGE.Application.EmployeeMng;
using EMPMANAGE.Domain.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EMPMANAGE.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IEmployeeManager _em;
        public IndexModel(ILogger<IndexModel> logger,IEmployeeManager em)
        {
            _logger = logger;
            _em = em;
        }

        

        public async Task OnGetAsync([FromServices] GetEmployees getEmp)
        {
            
            var employeeViewModels = await getEmp.Do();
            Employees = employeeViewModels.Select(x => new EmployeeVM
            {
                // Map properties from EmployeeViewModel to EmployeeVM
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Department = x.Department,
                Position = x.Position,
                Salary = x.Salary,
                HireDate = x.HireDate
            }).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            try
            {
                int result = await new DeleteEmployee(_em).Do(id);

                if (result > 0)
                {
                    TempData["SuccessMessage"] = "Employee deleted successfully";
                }
                else
                {
                    TempData["ErrorMessage"] = "Employee not found";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting employee: {ex.Message}";
            }

            return RedirectToPage(); // Refresh the current page
        }
        public IEnumerable<EmployeeVM> Employees { get; set; }

        public class EmployeeVM
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }

            public string Department { get; set; }
            public string Position { get; set; }
            public decimal Salary { get; set; }
            public DateTime HireDate { get; set; }
        }
    }
}
