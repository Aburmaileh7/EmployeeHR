using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EmployeeHR.ViewModels
{
    public class DepartmentViewModel
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Department Name")]   
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Abbreviation")]
        [StringLength(3)]
        public string Abbreviation { get; set; }
    }
}
