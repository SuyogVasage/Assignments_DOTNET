namespace CS_WebApp.Models
{
    public class EmployeeData
    {
        //[Required(ErrorMessage = "Manadatory Field")]
        // [NonLessThanEqualZero(ErrorMessage = "Employee Number Cannot Be Zero Or Negative")]
        public int EmpNo { get; set; }
        // [Required(ErrorMessage = "Manadatory Field")]
        // [Name(ErrorMessage = "Name Cannot Have Any Special Chars And Must Start With Capital Letter")]
        //[NameValidation(ErrorMessage = "Invalid Name Format")]
        public string EmpName { get; set; }
        // [Required(ErrorMessage = "Manadatory Field")]
        //[NonLessThanEqualZero(ErrorMessage = "Salary Cannot Be Zero Or Negative")]
        public int Salary { get; set; }
        //[Required(ErrorMessage = "Manadatory Field")]
        public string Designation { get; set; }
        // [Required(ErrorMessage = "Manadatory Field")]
        //public int DeptNo { get; set; }
        //[Required(ErrorMessage = "Manadatory Field")]
        public string Email { get; set; }
        public string DeptName { get; set; }

        public double Tax { get; set; }
    }
}
