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
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TestAppDbContext _context;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(TestAppDbContext context,
            ILogger<EmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            try
            {
                _logger.LogInformation("Adding new employee: {EmployeeName}", employee.FirstName);
                _context.Employees.Add(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee added successfully: {EmployeeName}", employee.FirstName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding employee: {EmployeeName}", employee.FirstName);
                throw;
            }
        }

        public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all employees");
                return await _context.Employees.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employees");
                throw;
            }
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving employee by ID: {EmployeeId}", id);
                return await _context.Employees.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee by ID: {EmployeeId}", id);
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(Employee employee)
        {
            try
            {
                _logger.LogInformation("Updating employee: {EmployeeName}", employee.FirstName);
                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Employee updated successfully: {EmployeeName}", employee.FirstName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee: {EmployeeName}", employee.FirstName);
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                _logger.LogInformation("Deleting employee by ID: {EmployeeId}", id);
                var employee = await GetEmployeeAsync(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Employee deleted successfully: {EmployeeId}", id);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting employee by ID: {EmployeeId}", id);
                throw;
            }
        }

    }
}
