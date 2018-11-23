using System.Collections.Generic;
using System.Threading.Tasks;
using TestMasGlobal.Entities;

namespace TestMasGlobal.Core.Bussiness.Interfaces
{
    public interface IEmployeeBussiness
    {
         Task<List<EmployeeDTO>> GetAllEmployees();
    }
}