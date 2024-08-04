using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class ManageUserViewModel
    {


        public string UserName { get; set; }

        [Required]
        public string PhoneNumder { get; set; }
    }
}
