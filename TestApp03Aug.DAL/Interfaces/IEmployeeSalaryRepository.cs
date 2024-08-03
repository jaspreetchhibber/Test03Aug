using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.DAL.Entities;

namespace TestApp03Aug.DAL.Interfaces
{
    public interface IEmployeeSalaryRepository
    {
        Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary);
    }
}
