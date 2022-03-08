using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace _8_March_CodeFirst_EFcore.Models
{
    public class Course
    {
        [Key]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public int CourseDuration { get; set; }
        public int Fees { get; set; }
        public string DegreeType { get; set; } 

        public ICollection<Student> Students { get; set; } 

    }
}