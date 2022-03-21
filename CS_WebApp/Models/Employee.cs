using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CS_WebApp.Models
{
    public partial class Employee
    {
        [Required(ErrorMessage = "EmpNo is Required")]
        public int EmpNo { get; set; }
        [Required(ErrorMessage = "EmpName is Required")]

        public string EmpName { get; set; }
        [Required(ErrorMessage = "Salary is Required")]

        public int Salary { get; set; }
        [Required(ErrorMessage = "Designation is Required")]

        public string Designation { get; set; }
        [Required(ErrorMessage = "DeptNo is Required")]

        [DeptNoCapacityAttribute (ErrorMessage = "Department is Full !!")]
        public int DeptNo { get; set; }
        [Required(ErrorMessage = "Email is Required")]

        public string Email { get; set; }

        public double Tax { get; set; }


        public virtual Department DeptNoNavigation { get; set; }
    }
}
