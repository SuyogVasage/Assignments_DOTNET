using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _8_March_CodeFirst_EFcore.Models
{
    public class Student
    {
        [Key]
        public int StudentUniqueID { get; set; }
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public int CourseID { get; set; }
        public int CourseYear { get; set; }
        public string  FeeStatus { get; set; }  
        public Course Course { get; set; }
    }
}

//StudentUniqueId, StudentId, StudentName, CourseId, CourseYear, FeesStatus
