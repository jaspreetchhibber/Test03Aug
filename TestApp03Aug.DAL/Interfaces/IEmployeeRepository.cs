using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.DAL.Entities;

namespace TestApp03Aug.DAL.Interfaces
{
    public interface IEmployeeRepository
    {
        Task AddEmployeeAsync(Employee employee);
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeAsync(int id);
        Task UpdateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int id);
    }
}
