using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.BLL.Models;

namespace TestApp03Aug.BLL.Interfaces
{
    public interface IEmployeeSalaryService
    {
        Task<EmployeeSalaryDto> AddEmployeeSalaryAsync(EmployeeSalaryDto employeeSalaryDto);
    }
}
