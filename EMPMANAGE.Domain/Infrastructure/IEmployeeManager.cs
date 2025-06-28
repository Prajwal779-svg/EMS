using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Models;

namespace EMPMANAGE.Domain.Infrastructure
{
    public interface IEmployeeManager
    {
        Task<int> CreateEmployee(Employee employee);
        Task<int> DeleteEmployee(int id);
        Task<int>  UpdateEmployee(Employee employee);
        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<List<Employee>> GetAll();

    }
}
