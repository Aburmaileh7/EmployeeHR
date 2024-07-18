using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;


namespace EmployeeHR.Data
{
    public class HRDBContext :DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options) { }
       
        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }

        public DbSet<PayrollModel> Payrolls {  get; set; }
    }
}
