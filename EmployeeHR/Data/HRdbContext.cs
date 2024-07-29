using EmployeeHR.Models;
using Microsoft.EntityFrameworkCore;
using EmployeeHR.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;



namespace EmployeeHR.Data
{
    public class HRDBContext : IdentityDbContext
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options) { }
       
        public DbSet<EmployeeModel> Employees { get; set; }

        public DbSet<DepartmentModel> Departments { get; set; }

        public DbSet<PayrollModel> Payrolls {  get; set; }

        //public DbSet<EmployeeHR.ViewModels.DepartmentViewModel> DepartmentViewModel { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "sec");
            builder.Entity<IdentityRole>().ToTable("Roles", "sec");

            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "sec");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "sec");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "sec");
            builder.Entity<IdentityUser>().ToTable("Users", "sec");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserToken", "sec");
        }
        public DbSet<EmployeeHR.ViewModels.RegeisterViewModel> RegeisterViewModel { get; set; } = default!;
        public DbSet<EmployeeHR.ViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
    }
}
