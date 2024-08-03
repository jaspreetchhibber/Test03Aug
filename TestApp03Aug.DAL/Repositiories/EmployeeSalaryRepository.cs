using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.DAL.Entities;
using TestApp03Aug.DAL.Interfaces;

namespace TestApp03Aug.DAL.Repositiories
{
    public class EmployeeSalaryRepository : IEmployeeSalaryRepository
    {
        private readonly TestAppDbContext _context;
        private readonly ILogger<EmployeeSalaryRepository> _logger;
        public EmployeeSalaryRepository(TestAppDbContext context,
            ILogger<EmployeeSalaryRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddEmployeeSalaryAsync(EmployeeSalary employeeSalary)
        {
            try
            {
                _logger.LogInformation("Adding Salary for employeeId: {Id}", employeeSalary.EmployeeId);
                _context.EmployeeSalaries.Add(employeeSalary);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Salary added successfully for employeeId: {Id}", employeeSalary.EmployeeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding Salary for employeeId: {Id}", employeeSalary.EmployeeId);
                throw;
            }
        }
    }
}
