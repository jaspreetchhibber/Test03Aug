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
    public class EmployeeSalaryService : IEmployeeSalaryService
    {
        private readonly IEmployeeSalaryRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeSalaryService> _logger;

        public EmployeeSalaryService(IEmployeeSalaryRepository repository, ILogger<EmployeeSalaryService> logger)
        {
            _repository = repository;
            _logger = logger;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<EmployeeSalary, EmployeeSalaryDto>().ReverseMap();
            });
            _mapper = config.CreateMapper();
        }

        public async Task<EmployeeSalaryDto> AddEmployeeSalaryAsync(EmployeeSalaryDto employeeSalaryDto)
        {
            try
            {
                _logger.LogInformation("Adding salary for employeeId: {Id}", $"{employeeSalaryDto.EmployeeId}");
                var employee = _mapper.Map<EmployeeSalary>(employeeSalaryDto);
                await _repository.AddEmployeeSalaryAsync(employee);
                _logger.LogInformation("Salary added successfully for employeeId: {Id}", $"{employeeSalaryDto.EmployeeId}");
                return employeeSalaryDto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding salary for employee id: {Id}", $"{employeeSalaryDto.EmployeeId}");
                throw;
            }
        }
    }
}
