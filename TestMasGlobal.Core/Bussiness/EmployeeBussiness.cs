using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Core.Bussiness.Interfaces;
using TestMasGlobal.Core.Data.Interfaces;
using TestMasGlobal.Entities;
using System.Linq;
using System;

namespace TestMasGlobal.Core.Bussiness
{
    public class EmployeeBussiness : IEmployeeBussiness
    {
        private readonly IEmployeeData _data;
        public EmployeeBussiness(IEmployeeData data)
        {
            _data = data;
        }
        public async Task<List<EmployeeDTO>> GetAllEmployees()  
        {
            return await _data.GetAllEmployees();
            //var listEmployees = new List<EmployeeDTO>();
            
            /* foreach (var employee in employees)
            {
                var enumContract = (ContractType)Enum.Parse(typeof(ContractType), employee.ContractTypeName);

                listEmployees.Add(new EmployeeDTO {
                    Id = employee.Id,
                    Name = employee.Name,
                    ContractTypeName =  employee.ContractTypeName,
                    Role = new Role(employee.RoleId, employee.RoleName, employee.RoleDescription),
                    Salary = enumContract == ContractType.HourlySalaryEmployee ? (120 * employee.HourlySalary * 12) : employee.MonthlySalary * 12,
                });
            } */

            //return listEmployees;
        }
    }
}