using AutoMapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.BLL.Interfaces;
using TestApp03Aug.BLL.Models;
using TestApp03Aug.DAL.Entities;
using TestApp03Aug.DAL.Interfaces;

namespace TestApp03Aug.BLL.Services
{
    public class EmployeeService :IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(IEmployeeRepository repository, ILogger<EmployeeService> logger)
        {
            _repository = repository;
            _logger = logger;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public async Task<EmployeeDto> AddEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                _logger.LogInformation("Adding new employee: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                var employee = _mapper.Map<Employee>(employeeDto);
                await _repository.AddEmployeeAsync(employee);
                _logger.LogInformation("Employee added successfully: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                return employeeDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding employee: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            try
            {
                _logger.LogInformation("Retrieving all employees");
                var employees = await _repository.GetAllEmployeesAsync();
                return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employees");
                throw;
            }
        }

        public async Task<EmployeeDto> GetEmployeeAsync(int id)
        {
            try
            {
                _logger.LogInformation("Retrieving employee by ID: {EmployeeId}", id);
                var employee = await _repository.GetEmployeeAsync(id);
                return _mapper.Map<EmployeeDto>(employee);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving employee by ID: {EmployeeId}", id);
                throw;
            }
        }

        public async Task UpdateEmployeeAsync(EmployeeDto employeeDto)
        {
            try
            {
                _logger.LogInformation("Updating employee: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                var employee = _mapper.Map<Employee>(employeeDto);
                await _repository.UpdateEmployeeAsync(employee);
                _logger.LogInformation("Employee updated successfully: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating employee: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                throw;
            }
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            try
            {
                var employeeDto = await GetEmployeeAsync(id);
                if (employeeDto != null)
                {
                    _logger.LogInformation("Deleting employee by ID: {EmployeeId} - {FullName}", id, $"{employeeDto.FirstName} {employeeDto.LastName}");
                    await _repository.DeleteEmployeeAsync(id);
                    _logger.LogInformation("Employee deleted successfully: {FullName}", $"{employeeDto.FirstName} {employeeDto.LastName}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting employee by ID: {Id}", id);
                throw;
            }
        }
    }
}
