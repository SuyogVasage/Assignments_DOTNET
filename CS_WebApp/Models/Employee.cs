using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CS_WebApp.Models
{
    public partial class Employee
    {
        [Required]
        public int EmpNo { get; set; }
        [IsEmpName(ErrorMessage ="Enter Valid EmpName")]
        [Remote("ValidateEmpName", "Employee", ErrorMessage = "Name should be FirstName MiddleName LastName")]
        public string EmpName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public int DeptNo { get; set; }
        [Required]
        public string Email { get; set; }
        public double Tax { get; set; }

        public virtual Department DeptNoNavigation { get; set; }
    }
}
