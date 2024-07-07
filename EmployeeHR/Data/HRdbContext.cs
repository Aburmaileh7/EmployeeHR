using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Data
{
    public class HRdbContext : DbContext
    {
        public HRdbContext(DbContextOptions<HRdbContext> options) : base(options) 
        {
            
        }


        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }

    }
}
