using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE.Application.EmployeeMng
{
    [Service]
    public class GetEmployee
    {
        private IEmployeeManager _employeeManager;
        public GetEmployee(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public async Task<EmployeeViewModel> Do(int id)
        {
           var emp= await _employeeManager.GetEmployeeByIdAsync(id);
            return  new EmployeeViewModel
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
