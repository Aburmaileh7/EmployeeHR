using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class RoleFormViewModel
    {
        public int id { get; set; }

        [Required]
        [Display(Name ="Role Name"),StringLength(50)]
        public string Name { get; set; }
    }
}
