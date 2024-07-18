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
        [Display(Name = "Payroll date")]
        [Column(TypeName ="datetime")]
        [DisplayFormat(DataFormatString ="{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime PayrollDate { get; set; }

        [Required]
        [Display(Name = "Bonus")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal Bonus { get; set; }

        [Required]
        [Display(Name = "Social Security Amount")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal SocialSecurityAmount { get; set; }

        [Display(Name = "Leaves(In Hours)")]
        [Column(TypeName = "float")]
        public float? Leaves { get; set; }


        [Required]
        [Display(Name = "Net Salary")]
        [Column(TypeName = "decimal(18,3)")]
        public decimal NetSalary { get; set; }




        [Required]
        [Display(Name = "Time Span")]
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
