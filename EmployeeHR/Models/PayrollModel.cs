using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHR.Models
{
    [Table("Payrolls",Schema ="dbo")]
    public class PayrollModel
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Display(Name ="Employee Name")]
        [Column(TypeName ="int")]
        public int EmployeeId { get; set; }


        [Required]
        [Display(Name = "payroll date")]
        [Column(TypeName ="datetime")]
        [DataType(DataType.Date)]
        public DateTime PayrollDate { get; set; }

        [Required]
        [Display(Name = "Bonus")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Bonus { get; set; }

        [Required]
        [Display(Name = "SSa")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal SSa { get; set; }

        [Display(Name = "Leaves(In Hours)")]
        [Column(TypeName = "float")]
        public float? Leaves { get; set; }


        [Required]
        [Display(Name = "Net Salary")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal NetSalary { get; set; }




        [Required]
        [Display(Name = "TotalSalary")]
        [Column(TypeName = "DateTime")]
        public DateTime TS { get; set; }




        [Required]
        [Display(Name = "Created By")]
        [Column(TypeName = "nvarchar(50)")]
        [StringLength(50)]
        public string CreatedBy { get; set; }

        [Display(Name = "Employee Name")]
        public virtual EmployeeModel Employee { get; set; }
    }
}
