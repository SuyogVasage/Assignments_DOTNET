using System.Collections.Generic;

namespace SampleWebApp.Models
{
    public class EmployeeEnt
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public int Salary { get; set; }
    }


    public class EmployeeEnts : List<EmployeeEnt>
    {
        public EmployeeEnts()
        {
            Add(new EmployeeEnt() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Salary = 11000 });
            Add(new EmployeeEnt() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Salary = 12000 });
            Add(new EmployeeEnt() { EmpNo = 103, EmpName = "Nandu", DeptName = "SL", Salary = 13000 });
            Add(new EmployeeEnt() { EmpNo = 104, EmpName = "Anil", DeptName = "IT", Salary = 14000 });
            Add(new EmployeeEnt() { EmpNo = 105, EmpName = "Jaywant", DeptName = "HR", Salary = 10000 });
            Add(new EmployeeEnt() { EmpNo = 106, EmpName = "Abhay", DeptName = "SL", Salary = 9000 });
            Add(new EmployeeEnt() { EmpNo = 107, EmpName = "Anil", DeptName = "IT", Salary = 8000 });
            Add(new EmployeeEnt() { EmpNo = 108, EmpName = "Shyam", DeptName = "HR", Salary = 7000 });
            Add(new EmployeeEnt() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Salary = 6000 });
            Add(new EmployeeEnt() { EmpNo = 110, EmpName = "Suprotim", DeptName = "IT", Salary = 5000 });
        }
    }
}
