using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestMasGlobal.Core.Bussiness.Interfaces;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeBussiness _logic;
        public EmployeesController(IEmployeeBussiness logic)
        {
            _logic = logic;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _logic.GetAllEmployees());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var employees = await _logic.GetAllEmployees();
            
            return Ok(employees.FirstOrDefault(i => i.Id == int.Parse(id)));
        }
    }
}
