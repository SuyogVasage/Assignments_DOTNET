using System.Collections.Generic;

namespace CS_WebApp.Models
{
    public class DeptEmpList
    {
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
        public int DeptNo { get; set; }

        public List<EmployeeData> EmployeeDatas { get; set; }
    }
}
