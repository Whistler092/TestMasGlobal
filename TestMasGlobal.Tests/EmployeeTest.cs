using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TestMasGlobal.Core.Bussiness;
using TestMasGlobal.Core.Data.Interfaces;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Tests {
    [TestClass]
    public class EmployeeTest {
        private Mock<IEmployeeData> employeeDataMock = null;
        private EmployeeBussiness employeeBussiness = null;

        [TestInitialize]
        public void InitializeTest () {
            this.employeeDataMock = new Mock<IEmployeeData> ();
            this.employeeBussiness = new EmployeeBussiness (
                this.employeeDataMock.Object);
        }

        [TestMethod]
        public async Task GetListWithRecords () {
            List<EmployeeDTO> employeesExpected = new List<EmployeeDTO> {
                new EmployeeDTO {
                Id = 1,
                Name = "Juan",
                ContractTypeName = ContractType.HourlySalaryEmployee.ToString (),
                Role = new Role (1, "Administrator", null),
                Salary = (120 * 60000 * 12)
                },
                new EmployeeDTO {
                Id = 1,
                Name = "Sebastian",
                ContractTypeName = ContractType.MonthlySalaryEmployee.ToString (),
                Role = new Role (2, "Contractor", null),
                Salary = (80000 * 12)
                },
            };

            List<EmployeeDTO> employeesReal;

            this.employeeDataMock.Setup (it => it.GetAllEmployees ())
                .Returns (Task.FromResult (new List<Employee> {
                    new Employee {
                        Id = 1,
                            Name = "Juan",
                            ContractTypeName = ContractType.HourlySalaryEmployee.ToString (),
                            HourlySalary = 60000,
                            MonthlySalary = 80000,
                            RoleId = 1,
                            RoleName = "Administrator",
                            RoleDescription = null
                    },
                    new Employee {
                        Id = 1,
                            Name = "Sebastian",
                            ContractTypeName = ContractType.MonthlySalaryEmployee.ToString (),
                            HourlySalary = 60000,
                            MonthlySalary = 80000,
                            RoleId = 2,
                            RoleName = "Contractor",
                            RoleDescription = null
                    }
                }));

            employeesReal = await this.employeeBussiness.GetAllEmployees ();

            Assert.AreEqual (employeesExpected.Count, employeesReal.Count);
            Assert.AreEqual (employeesExpected[0].Salary, (120 * 60000 * 12));
            Assert.AreEqual (employeesExpected[1].Salary, (80000 * 12));
        }
    }
}