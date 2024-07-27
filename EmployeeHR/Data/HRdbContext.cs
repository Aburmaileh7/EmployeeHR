using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeHR.ViewModels;


namespace EmployeeHR.Data
{
    public class HRDBContext :DbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options) { }
       
        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }

        public DbSet<PayrollModel> Payrolls {  get; set; }
        public DbSet<EmployeeHR.ViewModels.DepartmentViewModel> DepartmentViewModel { get; set; } = default!;
    }
}
