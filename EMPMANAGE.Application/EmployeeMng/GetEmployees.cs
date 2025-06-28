using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE.Application.EmployeeMng
{
    [Service]
    public class GetEmployees
    {
        private IEmployeeManager _employeeManager;

        public GetEmployees(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        public async Task<List<EmployeeViewModel>> Do()
        {
            var employees = await _employeeManager.GetAll(); // First await the Task
            return employees.Select(x => new EmployeeViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Department = x.Department,
                Position = x.Position,
                Salary = x.Salary,
                HireDate = x.HireDate
            }).ToList();
        }
        public class EmployeeViewModel
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
