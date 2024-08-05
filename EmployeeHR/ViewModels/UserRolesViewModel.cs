using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class UserRolesViewModel
    {

        //checkbox view model general

        [Key]
        public string UserId { get; set; }

        public string UserName { get; set; }

        public List<RoleViewModel> Roles { get; set; }
    }
}
