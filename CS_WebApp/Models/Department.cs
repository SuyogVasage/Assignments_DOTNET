using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CS_WebApp.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }
        [NonNegative(ErrorMessage = "Enter Positive Number")]
        [Required]
        public int DeptNo { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public string Location { get; set; }
        [NonNegative(ErrorMessage = "Enter Positive Number")]
        [Required]
        public int Capacity { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
