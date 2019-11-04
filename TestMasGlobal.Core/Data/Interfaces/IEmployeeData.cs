using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Core.Data.Interfaces
{
    public interface IEmployeeData
    {
         Task<List<EmployeeDTO>> GetAllEmployees();
    }
}