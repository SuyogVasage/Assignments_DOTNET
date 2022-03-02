using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_March_CRUD_Async
{
    internal class Employee
    {
        public int EmpNo { get; set; }
        public string EmpName { get; set; }
        public int Salary { get; set; }
        public string Designation { get; set; }
        public int DeptNo { get; set; }
        public string Email { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
