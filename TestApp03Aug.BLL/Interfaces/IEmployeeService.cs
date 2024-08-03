using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.BLL.Models;

namespace TestApp03Aug.BLL.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto> GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(EmployeeDto employeeDto);
        Task DeleteEmployeeAsync(int id);
    }
}
