using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class LoginViewModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
