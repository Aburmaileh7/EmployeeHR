using EmployeeHR.Data;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();





builder.Services.AddControllersWithViews();



IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory
    .GetCurrentDirectory())
    .AddJsonFile("appsettings.json").Build();

var connectionString = configuration.GetConnectionString("HRConnectionString");

builder.Services.AddDbContext<HRdbContext>(option => option.UseSqlServer(connectionString));





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
