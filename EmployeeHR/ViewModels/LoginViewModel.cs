﻿
using System.ComponentModel.DataAnnotations;

namespace EmployeeHR.ViewModels
{
    public class LoginViewModel
    {
        public int id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
