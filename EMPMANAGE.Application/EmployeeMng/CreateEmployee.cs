using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;

namespace EMPMANAGE.Application.EmployeeMng
{
    [Service]
    public class CreateEmployee
    {
        private IEmployeeManager _em;
        public CreateEmployee(IEmployeeManager em)
        {
            _em = em;
        }
        public async Task<Response> Do(Request request)
        {
            var employee = new EMPMANAGE.Domain.Models.Employee()
            {
                Name = request.Name,
                Id = request.Id,
                Email = request.Email,
                Department = request.Department,
                Position = request.Position,
                Salary = request.Salary,
                HireDate = request.HireDate
            };

            if (await _em.CreateEmployee(employee) <= 0)
            {
                throw new Exception("Failed to create Employee");
            }

            return new Response
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Department = request.Department,
                Position = request.Position,
                Salary = request.Salary,
                HireDate = request.HireDate
            };
        }

        private Exception Exception()
        {
            throw new NotImplementedException();
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
