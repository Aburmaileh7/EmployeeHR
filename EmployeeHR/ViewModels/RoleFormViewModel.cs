using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class RoleFormViewModel
    {
        public int id { get; set; }

        [Required]
     
        public string Name { get; set; }
    }
}
