using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Core.Data.Interfaces;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Core.Data
{
    public class EmployeeData : ApiClient, IEmployeeData
    {
        public EmployeeData() 
            : base(new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees"))
        {
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await this.GetAsync<List<Employee>>(this.BaseEndpoint);
        }
    }
}
