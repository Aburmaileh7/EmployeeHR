using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeHR.Data
{
    public class HRdbContext : DbContext
    {
        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }

    }
}
