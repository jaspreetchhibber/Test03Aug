using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp03Aug.DAL.Entities;

namespace TestApp03Aug.DAL
{
    public class TestAppDbContext : DbContext
    {
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        {
        }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey(e => e.Id);
        }

    }
}
