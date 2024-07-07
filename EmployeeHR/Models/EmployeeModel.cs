﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeHR.Models
{
    [Table("Employees", Schema ="dbo")]
    public class EmployeeModel
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name ="Employee ID")]
        public int Id { get; set; }

        [Required (ErrorMessage ="Please Type First Name")]
        [StringLength(50)]
        [Column(TypeName ="NVARCHAR(50)")]
        [Display(Name ="First Name")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Please Type Last Name")]
        [StringLength(50)]
        [Column(TypeName = "NVARCHAR(50)")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display (Name ="Hiring Date")]
        [DisplayFormat(DataFormatString ="{0:dd.mm.yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime HiringDate { get; set; }

        [Required]
        [Display(Name ="Birth Of Date")]
        [DisplayFormat(DataFormatString = "{0:dd.mm.yyyy}")]
        [Column(TypeName = "datetime")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Please Enter Employee Salary")]
        [Display(Name = "Salary")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Salary { get; set; }


        [Display(Name = "Active")]
        [Column(TypeName = "bit")]
        public bool  IsActive  { get; set; }


        [Required]
        [Display(Name ="Depatment ID")]
        [Column(TypeName = "int")]
        public int DepartmentId { get; set; }


        [Display(Name ="Employee Email")]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvachar(100)")]
        [StringLength(100)]
        public string? Email { get; set; }

        [Display(Name ="Department")]
        public virtual DepartmentModel Department { get; set; }
    }
}
