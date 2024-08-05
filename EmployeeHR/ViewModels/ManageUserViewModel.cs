using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class ManageUserViewModel
    {
        [Key]
        public int id { get; set; }

        public string UserName { get; set; }

        [Required]
        public string PhoneNumder { get; set; }
    }
}
