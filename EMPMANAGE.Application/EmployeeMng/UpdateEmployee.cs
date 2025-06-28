using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE.Application.EmployeeMng
{
    [Service]
    public class UpdateEmployee
    {
       private IEmployeeManager _employeeManager;

        public UpdateEmployee(IEmployeeManager emp)
        {
            _employeeManager = emp;
        }

        public async Task<Response> Do(Request request)
        {
            var emp= await _employeeManager.GetEmployeeByIdAsync(request.Id);
            emp.Id = request.Id;
            emp.Name=request.Name;
            emp.Email=request.Email;
            emp.Department=request.Department;
            emp.Position=request.Position;
            emp.Salary=request.Salary;
            emp.HireDate=request.HireDate;
            await _employeeManager.UpdateEmployee(emp);
            return new Response
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
        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Department { get; set; }
            public string Position { get; set; }
            public decimal Salary { get; set; }
            public DateTime HireDate { get; set; }
        }

        public class Response
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
