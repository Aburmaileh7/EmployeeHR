using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using EmployeeHR.Data;

namespace EmployeeHR.Components
{
    public class EmployeeCont :ViewComponent
    {
        //database/////////////////////
        private readonly HRDBContext _dbcontext;
        public EmployeeCont(HRDBContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public ContentViewComponentResult Invoke()
        {
            var cont = _dbcontext.Employees.Count();
            return Content($"Num Employee {cont}") ;
        }
    }
}
