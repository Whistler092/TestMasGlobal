using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Core.Data.Interfaces;
using TestMasGlobal.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace TestMasGlobal.Core.Data {
    public class EmployeeData : ApiClient, IEmployeeData {
        private EmployeesContext _context;
        public EmployeeData (EmployeesContext context) :
         base (new Uri ("http://masglobaltestapi.azurewebsites.net/api/Employees")) { 
             _context = context;
         }

        public async Task<List<EmployeeDTO>> GetAllEmployees () {
            //return await this.GetAsync<List<Employee>> (this.BaseEndpoint);
            return await _context.Employees.ToListAsync();
        }
    }
}