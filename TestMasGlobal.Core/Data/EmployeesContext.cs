namespace TestMasGlobal.Core.Data {

    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Microsoft.EntityFrameworkCore;
    using TestMasGlobal.Entities;

    public class EmployeesContext : DbContext {

        public EmployeesContext () : base () {

        }

        public new DbSet<EmployeeDTO> Employees { get; set; }

        public new DbSet<Role> Roles { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase ("Employees");

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            base.OnModelCreating (modelBuilder);

            List<Role> roles = new List<Role> {
                new Role (1, "Administrator", null),
                new Role (2, "Contractor", null),
            };
            modelBuilder.Entity<Role> ().HasData (roles.ToArray ());

            List<EmployeeDTO> employeesExpected = new List<EmployeeDTO> {
                new EmployeeDTO {
                Id = 1,
                Name = "Juan",
                ContractTypeName = ContractType.HourlySalaryEmployee.ToString (),
                RoleId = 1,
                Salary = (120 * 60000 * 12)
                },
                new EmployeeDTO {
                Id = 2,
                Name = "Sebastian",
                ContractTypeName = ContractType.MonthlySalaryEmployee.ToString (),
                RoleId = 2,
                Salary = (80000 * 12)
                },
            };
            modelBuilder.Entity<EmployeeDTO> ().HasData (employeesExpected.ToArray ());

        }
    }
}