using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.DAL.Entities;

namespace TestApp03Aug.BLL.Models
{
    public class EmployeeSalaryDto
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public DateTime SalaryDate { get; set; }
        public decimal Amount { get; set; }
    }
}
