using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApp03Aug.BLL.Interfaces;
using TestApp03Aug.Models;
using TestApp03Aug.BLL.Models;

namespace TestApp03Aug.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeSalaryService _employeeSalaryService;

        public HomeController(ILogger<HomeController> logger, 
            IEmployeeService employeeService,
            IEmployeeSalaryService employeeSalaryService)
        {
            _logger = logger;
            _employeeService = employeeService;
            _employeeSalaryService = employeeSalaryService;
        }

        public async Task<IActionResult> Index()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return View(employees);
        }

        // GET: Employee/AddEmployee  
        public IActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.AddEmployeeAsync(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            return View(employeeDto);
        }

        public async Task<IActionResult> EditEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);
            return PartialView("_Employee", employee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                await _employeeService.UpdateEmployeeAsync(employeeDto);
                return RedirectToAction(nameof(Index));
            }
            return PartialView("_Employee", employeeDto);
        }

        // GET: Employee/AddMonthlySalary  
        public IActionResult AddMonthlySalary()
        {
            ViewBag.Employees = _employeeService.GetAllEmployeesAsync().Result;
            return View();
        }

        // POST: Employee/AddMonthlySalary  
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMonthlySalary(EmployeeSalaryDto employeeSalaryDto)
        {
            if (ModelState.IsValid)
            {
                await _employeeSalaryService.AddEmployeeSalaryAsync(employeeSalaryDto);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Employees = _employeeService.GetAllEmployeesAsync().Result;
            return View(employeeSalaryDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
