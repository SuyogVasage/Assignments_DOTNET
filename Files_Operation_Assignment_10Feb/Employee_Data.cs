using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Operation_Assignment_10Feb 
{
    [Serializable]
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Suyog  ", DeptName = "IT     ", Designation = "Director", Salary = 70000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Ajay   ", DeptName = "HR     ", Designation = "Director", Salary = 65000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Mayur  ", DeptName = "Admin  ", Designation = "Director", Salary = 73000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Durvesh", DeptName = "SL     ", Designation = "Director", Salary = 60000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Pranav ", DeptName = "Account", Designation = "Director", Salary = 70000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Shikhar", DeptName = "IT     ", Designation = "Manager ", Salary = 50000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Uday   ", DeptName = "HR     ", Designation = "Manager ", Salary = 45000 });
            Add(new Employee() { EmpNo = 108, EmpName = "Deepak ", DeptName = "Admin  ", Designation = "Manager ", Salary = 48000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Raman  ", DeptName = "SL     ", Designation = "Manager ", Salary = 40000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Sasi   ", DeptName = "Account", Designation = "Manager ", Salary = 60000 });

            Add(new Employee() { EmpNo = 111, EmpName = "Mit    ", DeptName = "IT     ", Designation = "Intern  ", Salary = 11000 });
            Add(new Employee() { EmpNo = 112, EmpName = "Tejas  ", DeptName = "HR     ", Designation = "Engineer", Salary = 30000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Manish ", DeptName = "SL     ", Designation = "Intern  ", Salary = 13000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Soham  ", DeptName = "Admin  ", Designation = "Staff   ", Salary = 10000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Esha   ", DeptName = "Account", Designation = "Intern  ", Salary = 10000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Ankita ", DeptName = "SL     ", Designation = "Engineer", Salary = 29000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Jahanvi", DeptName = "Account", Designation = "Manager ", Salary = 48000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Yash   ", DeptName = "HR     ", Designation = "Engineer", Salary = 65000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Onkar  ", DeptName = "Admin  ", Designation = "Staff   ", Salary = 9000  });
            Add(new Employee() { EmpNo = 120, EmpName = "Harsh  ", DeptName = "IT     ", Designation = "Engineer", Salary = 25000 });

            Add(new Employee() { EmpNo = 121, EmpName = "Shreya ", DeptName = "Account", Designation = "Manager ", Salary = 41000 });
            Add(new Employee() { EmpNo = 122, EmpName = "Ankita ", DeptName = "HR     ", Designation = "Engineer", Salary = 32000 });
            Add(new Employee() { EmpNo = 123, EmpName = "Sameer ", DeptName = "SL     ", Designation = "Intern  ", Salary = 13000 });
            Add(new Employee() { EmpNo = 124, EmpName = "Rohan  ", DeptName = "IT     ", Designation = "Staff   ", Salary = 14000 });
            Add(new Employee() { EmpNo = 125, EmpName = "Mandar ", DeptName = "HR     ", Designation = "Intern  ", Salary = 10000 });
            Add(new Employee() { EmpNo = 126, EmpName = "Mrunal ", DeptName = "Admin  ", Designation = "Engineer", Salary = 9000 });
            Add(new Employee() { EmpNo = 127, EmpName = "Simran ", DeptName = "IT     ", Designation = "Intern  ", Salary = 8000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Preeti ", DeptName = "Account", Designation = "Engineer", Salary = 37000 });
            Add(new Employee() { EmpNo = 129, EmpName = "Salina ", DeptName = "SL     ", Designation = "Staff   ", Salary = 9000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Noaf   ", DeptName = "Admin  ", Designation = "Engineer", Salary = 35000 });

            Add(new Employee() { EmpNo = 131, EmpName = "Radiya ", DeptName = "SL     ", Designation = "Manager ", Salary = 50000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Prachi ", DeptName = "HR     ", Designation = "Engineer", Salary = 30000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Akshata", DeptName = "SL     ", Designation = "Intern  ", Salary = 13000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Nikita ", DeptName = "IT     ", Designation = "Staff   ", Salary = 14000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Navnath", DeptName = "Admin  ", Designation = "Engineer", Salary = 34000 });
            Add(new Employee() { EmpNo = 136, EmpName = "Mayur  ", DeptName = "SL     ", Designation = "Engineer", Salary = 23000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Harshda", DeptName = "Admin  ", Designation = "Intern  ", Salary = 8000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Divyesh", DeptName = "HR     ", Designation = "Engineer", Salary = 27000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Sairaj ", DeptName = "Account", Designation = "Staff   ", Salary = 7000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Kaushik", DeptName = "IT     ", Designation = "Engineer", Salary = 35000 });

            Add(new Employee() { EmpNo = 141, EmpName = "Mahesh ", DeptName = "IT     ", Designation = "Intern  ", Salary = 11000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Tejas  ", DeptName = "HR     ", Designation = "Engineer", Salary = 33000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Nandu  ", DeptName = "SL     ", Designation = "Intern  ", Salary = 12000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Anil   ", DeptName = "Admin  ", Designation = "Staff   ", Salary = 14000 });
            Add(new Employee() { EmpNo = 145, EmpName = "Jaywant", DeptName = "Account", Designation = "Staff   ", Salary = 7000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Abhay  ", DeptName = "SL     ", Designation = "Manager ", Salary = 50000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Anil   ", DeptName = "Admin  ", Designation = "Intern  ", Salary = 9000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Shyam  ", DeptName = "HR     ", Designation = "Engineer", Salary = 28000 });
            Add(new Employee() { EmpNo = 149, EmpName = "Vikram ", DeptName = "Account", Designation = "Staff   ", Salary = 15000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Shubham", DeptName = "IT     ", Designation = "Engineer", Salary = 30000 });
        }
    }
}

