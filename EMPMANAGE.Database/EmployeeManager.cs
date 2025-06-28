using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Infrastructure;
using EMPMANAGE.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EMPMANAGE.Database
{
    public class EmployeeManager : IEmployeeManager
    {
        private EmpDbContext _ctx;
        public EmployeeManager(EmpDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<int> CreateEmployee(Employee employee)
        {
            try
            {
                _ctx.Employees.Add(employee);
                return await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log the exception here
                Console.WriteLine($"CreateEmployee Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> DeleteEmployee(int id)
        {
            try
            {
                var emp = await _ctx.Employees.FirstOrDefaultAsync(x => x.Id == id);
                if (emp == null)
                    return 0;

                _ctx.Employees.Remove(emp);
                return await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"DeleteEmployee Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<List<Employee>> GetAll()
        {
            try
            {
                return await _ctx.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetAll Error: {ex.Message}");
                return new List<Employee>();
            }
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {
                return await _ctx.Employees.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"GetEmployeeByIdAsync Error: {ex.Message}");
                return null;
            }
        }

        public async Task<int> UpdateEmployee(Employee employee)
        {
            try
            {
                _ctx.Employees.Update(employee);
                return await _ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"UpdateEmployee Error: {ex.Message}");
                return 0;
            }
        }

    }
}
