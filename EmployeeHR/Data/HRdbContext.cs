using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Data
{
    public class HRDbContext : DbContext
    {
        public HRDbContext(DbContextOptions<HRDbContext> options) : base(options) { }
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<DepartmentModel> Departments { get; set; }
    }
}
