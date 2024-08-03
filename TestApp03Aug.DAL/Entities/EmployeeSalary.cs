using Azure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp03Aug.DAL.Entities
{
    public class EmployeeSalary
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        public DateTime SalaryDate { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual Employee Employee { get; set; }

    }
}
