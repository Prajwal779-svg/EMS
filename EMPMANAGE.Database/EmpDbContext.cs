using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMPMANAGE.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EMPMANAGE.Database
{
    public class EmpDbContext:IdentityDbContext
    {
        public EmpDbContext(DbContextOptions<EmpDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>().HasData(
                    new Employee
                    {
                        Id = 1,
                        Name = "Mary",
                        Email = "mary@pragimtech.com",
                        Department = "IT", // Make sure to include this required field
                        Position = "Developer",
                        Salary = 60000.00m,
                        HireDate = new DateTime(2020, 1, 15)

                    }

                );

        }

    }

    
}
