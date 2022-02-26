using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment_9_Feb
{
    internal class Employees : List<Employee>
    {
        public Employees()
        {
            Add(new Employee() { EmpNo = 101, EmpName = "Mahesh", DeptName = "IT", Designation = "Director", Salary = 70000 });
            Add(new Employee() { EmpNo = 102, EmpName = "Tejas", DeptName = "HR", Designation = "Director", Salary = 65000 });
            Add(new Employee() { EmpNo = 103, EmpName = "Nandu", DeptName = "Admin", Designation = "Director", Salary = 73000 });
            Add(new Employee() { EmpNo = 104, EmpName = "Anil", DeptName = "SL", Designation = "Director", Salary = 60000 });
            Add(new Employee() { EmpNo = 105, EmpName = "Jaywant", DeptName = "Account", Designation = "Director", Salary = 70000 });
            Add(new Employee() { EmpNo = 106, EmpName = "Abhay", DeptName = "IT", Designation = "Manager", Salary = 50000 });
            Add(new Employee() { EmpNo = 107, EmpName = "Anil", DeptName = "HR", Designation = "Manager", Salary = 45000 });
            Add(new Employee() { EmpNo = 108, EmpName = "Shyam", DeptName = "Admin", Designation = "Manager", Salary = 48000 });
            Add(new Employee() { EmpNo = 109, EmpName = "Vikram", DeptName = "SL", Designation = "Manager", Salary = 40000 });
            Add(new Employee() { EmpNo = 110, EmpName = "Suprotim", DeptName = "Account", Designation = "Manager", Salary = 60000 });

            Add(new Employee() { EmpNo = 111, EmpName = "Mahesh", DeptName = "IT", Designation = "Intern", Salary = 11000 });
            Add(new Employee() { EmpNo = 112, EmpName = "Tejas", DeptName = "HR", Designation = "Engineer", Salary = 30000 });
            Add(new Employee() { EmpNo = 113, EmpName = "Nandu", DeptName = "SL", Designation = "Intern", Salary = 13000 });
            Add(new Employee() { EmpNo = 114, EmpName = "Anil", DeptName = "Admin", Designation = "Staff", Salary = 10000 });
            Add(new Employee() { EmpNo = 115, EmpName = "Jaywant", DeptName = "Account", Designation = "Intern", Salary = 10000 });
            Add(new Employee() { EmpNo = 116, EmpName = "Abhay", DeptName = "SL", Designation = "Engineer", Salary = 29000 });
            Add(new Employee() { EmpNo = 117, EmpName = "Anil", DeptName = "Account", Designation = "Manager", Salary = 48000 });
            Add(new Employee() { EmpNo = 118, EmpName = "Shyam", DeptName = "HR", Designation = "Engineer", Salary = 65000 });
            Add(new Employee() { EmpNo = 119, EmpName = "Vikram", DeptName = "Admin", Designation = "Staff", Salary = 9000 });
            Add(new Employee() { EmpNo = 120, EmpName = "Suprotim", DeptName = "IT", Designation = "Engineer", Salary = 25000 });

            Add(new Employee() { EmpNo = 121, EmpName = "Mahesh", DeptName = "Account", Designation = "Manager", Salary = 41000 });
            Add(new Employee() { EmpNo = 122, EmpName = "Tejas", DeptName = "HR", Designation = "Engineer", Salary = 32000 });
            Add(new Employee() { EmpNo = 123, EmpName = "Nandu", DeptName = "SL", Designation = "Intern", Salary = 13000 });
            Add(new Employee() { EmpNo = 124, EmpName = "Anil", DeptName = "IT", Designation = "Staff", Salary = 14000 });
            Add(new Employee() { EmpNo = 125, EmpName = "Jaywant", DeptName = "HR", Designation = "Intern", Salary = 10000 });
            Add(new Employee() { EmpNo = 126, EmpName = "Abhay", DeptName = "Admin", Designation = "Engineer", Salary = 9000 });
            Add(new Employee() { EmpNo = 127, EmpName = "Anil", DeptName = "IT", Designation = "Intern", Salary = 8000 });
            Add(new Employee() { EmpNo = 128, EmpName = "Shyam", DeptName = "Account", Designation = "Engineer", Salary = 37000 });
            Add(new Employee() { EmpNo = 129, EmpName = "Vikram", DeptName = "SL", Designation = "Staff", Salary = 9000 });
            Add(new Employee() { EmpNo = 130, EmpName = "Suprotim", DeptName = "Admin", Designation = "Engineer", Salary = 35000 });

            Add(new Employee() { EmpNo = 131, EmpName = "Mahesh", DeptName = "SL", Designation = "Manager", Salary = 50000 });
            Add(new Employee() { EmpNo = 132, EmpName = "Tejas", DeptName = "HR", Designation = "Engineer", Salary = 30000 });
            Add(new Employee() { EmpNo = 133, EmpName = "Nandu", DeptName = "SL", Designation = "Intern", Salary = 13000 });
            Add(new Employee() { EmpNo = 134, EmpName = "Anil", DeptName = "IT", Designation = "Staff", Salary = 14000 });
            Add(new Employee() { EmpNo = 135, EmpName = "Jaywant", DeptName = "Admin", Designation = "Engineer", Salary = 34000 });
            Add(new Employee() { EmpNo = 136, EmpName = "Abhay", DeptName = "SL", Designation = "Engineer", Salary = 23000 });
            Add(new Employee() { EmpNo = 137, EmpName = "Anil", DeptName = "Admin", Designation = "Intern", Salary = 8000 });
            Add(new Employee() { EmpNo = 138, EmpName = "Shyam", DeptName = "HR", Designation = "Engineer", Salary = 27000 });
            Add(new Employee() { EmpNo = 139, EmpName = "Vikram", DeptName = "Account", Designation = "Staff", Salary = 7000 });
            Add(new Employee() { EmpNo = 140, EmpName = "Suprotim", DeptName = "IT", Designation = "Engineer", Salary = 35000 });

            Add(new Employee() { EmpNo = 141, EmpName = "Mahesh", DeptName = "IT", Designation = "Intern", Salary = 11000 });
            Add(new Employee() { EmpNo = 142, EmpName = "Tejas", DeptName = "HR", Designation = "Engineer", Salary = 33000 });
            Add(new Employee() { EmpNo = 143, EmpName = "Nandu", DeptName = "SL", Designation = "Intern", Salary = 12000 });
            Add(new Employee() { EmpNo = 144, EmpName = "Anil", DeptName = "Admin", Designation = "Staff", Salary = 14000 });
            Add(new Employee() { EmpNo = 145, EmpName = "Jaywant", DeptName = "Account", Designation = "Staff", Salary = 7000 });
            Add(new Employee() { EmpNo = 146, EmpName = "Abhay", DeptName = "SL", Designation = "Manager", Salary = 50000 });
            Add(new Employee() { EmpNo = 147, EmpName = "Anil", DeptName = "Admin", Designation = "Intern", Salary = 9000 });
            Add(new Employee() { EmpNo = 148, EmpName = "Shyam", DeptName = "HR", Designation = "Engineer", Salary = 28000 });
            Add(new Employee() { EmpNo = 149, EmpName = "Vikram", DeptName = "Account", Designation = "Staff", Salary = 15000 });
            Add(new Employee() { EmpNo = 150, EmpName = "Suprotim", DeptName = "IT", Designation = "Engineer", Salary = 30000 });
        }
    }

    internal class EmployeesToJoin : List<EmployeeToJoin>
    {
        public EmployeesToJoin()
        {
            Add(new EmployeeToJoin() { EmpNo = 101, EmpName = "Mahesh", DeptNo = 5, Designation = "Director", Salary = 70000 });
            Add(new EmployeeToJoin() { EmpNo = 102, EmpName = "Tejas", DeptNo = 4, Designation = "Director", Salary = 65000 });
            Add(new EmployeeToJoin() { EmpNo = 103, EmpName = "Nandu", DeptNo = 1, Designation = "Director", Salary = 73000 });
            Add(new EmployeeToJoin() { EmpNo = 104, EmpName = "Anil", DeptNo = 2, Designation = "Director", Salary = 60000 });
            Add(new EmployeeToJoin() { EmpNo = 105, EmpName = "Jaywant", DeptNo = 10, Designation = "Director", Salary = 60000 });
            Add(new EmployeeToJoin() { EmpNo = 106, EmpName = "Abhay", DeptNo = 4, Designation = "Manager", Salary = 50000 });
            Add(new EmployeeToJoin() { EmpNo = 107, EmpName = "Anil", DeptNo = 4, Designation = "Manager", Salary = 45000 });
            Add(new EmployeeToJoin() { EmpNo = 108, EmpName = "Shyam", DeptNo = 3, Designation = "Manager", Salary = 48000 });
            Add(new EmployeeToJoin() { EmpNo = 109, EmpName = "Vikram", DeptNo = 4, Designation = "Manager", Salary = 40000 });
            Add(new EmployeeToJoin() { EmpNo = 110, EmpName = "Suprotim", DeptNo = 1, Designation = "Manager", Salary = 60000 });

            Add(new EmployeeToJoin() { EmpNo = 111, EmpName = "Mahesh", DeptNo = 9, Designation = "Intern", Salary = 11000 });
            Add(new EmployeeToJoin() { EmpNo = 112, EmpName = "Tejas", DeptNo = 5, Designation = "Engineer", Salary = 30000 });
            Add(new EmployeeToJoin() { EmpNo = 113, EmpName = "Nandu", DeptNo = 10, Designation = "Intern", Salary = 13000 });
            Add(new EmployeeToJoin() { EmpNo = 114, EmpName = "Anil", DeptNo = 2, Designation = "Staff", Salary = 10000 });
            Add(new EmployeeToJoin() { EmpNo = 115, EmpName = "Jaywant", DeptNo = 4, Designation = "Intern", Salary = 10000 });
            Add(new EmployeeToJoin() { EmpNo = 116, EmpName = "Abhay", DeptNo = 10, Designation = "Engineer", Salary = 29000 });
            Add(new EmployeeToJoin() { EmpNo = 117, EmpName = "Anil", DeptNo = 1, Designation = "Manager", Salary = 48000 });
            Add(new EmployeeToJoin() { EmpNo = 118, EmpName = "Shyam", DeptNo = 2, Designation = "Engineer", Salary = 37000 });
            Add(new EmployeeToJoin() { EmpNo = 119, EmpName = "Vikram", DeptNo = 3, Designation = "Staff", Salary = 9000 });
            Add(new EmployeeToJoin() { EmpNo = 120, EmpName = "Suprotim", DeptNo = 4, Designation = "Engineer", Salary = 25000 });

            Add(new EmployeeToJoin() { EmpNo = 121, EmpName = "Mahesh", DeptNo = 6, Designation = "Manager", Salary = 41000 });
            Add(new EmployeeToJoin() { EmpNo = 122, EmpName = "Tejas", DeptNo = 8, Designation = "Engineer", Salary = 32000 });
            Add(new EmployeeToJoin() { EmpNo = 123, EmpName = "Nandu", DeptNo = 2, Designation = "Intern", Salary = 13000 });
            Add(new EmployeeToJoin() { EmpNo = 124, EmpName = "Anil", DeptNo = 10, Designation = "Staff", Salary = 14000 });
            Add(new EmployeeToJoin() { EmpNo = 125, EmpName = "Jaywant", DeptNo = 1, Designation = "Intern", Salary = 10000 });
            Add(new EmployeeToJoin() { EmpNo = 126, EmpName = "Abhay", DeptNo = 10, Designation = "Engineer", Salary = 9000 });
            Add(new EmployeeToJoin() { EmpNo = 127, EmpName = "Anil", DeptNo = 7, Designation = "Intern", Salary = 8000 });
            Add(new EmployeeToJoin() { EmpNo = 128, EmpName = "Shyam", DeptNo = 3, Designation = "Engineer", Salary = 37000 });
            Add(new EmployeeToJoin() { EmpNo = 129, EmpName = "Vikram", DeptNo = 7, Designation = "Staff", Salary = 9000 });
            Add(new EmployeeToJoin() { EmpNo = 130, EmpName = "Suprotim", DeptNo = 8, Designation = "Engineer", Salary = 35000 });

            Add(new EmployeeToJoin() { EmpNo = 131, EmpName = "Mahesh", DeptNo = 6, Designation = "Manager", Salary = 50000 });
            Add(new EmployeeToJoin() { EmpNo = 132, EmpName = "Tejas", DeptNo = 7, Designation = "Engineer", Salary = 30000 });
            Add(new EmployeeToJoin() { EmpNo = 133, EmpName = "Nandu", DeptNo = 1, Designation = "Intern", Salary = 13000 });
            Add(new EmployeeToJoin() { EmpNo = 134, EmpName = "Anil", DeptNo = 3, Designation = "Staff", Salary = 14000 });
            Add(new EmployeeToJoin() { EmpNo = 135, EmpName = "Jaywant", DeptNo = 10, Designation = "Engineer", Salary = 34000 });
            Add(new EmployeeToJoin() { EmpNo = 136, EmpName = "Abhay", DeptNo = 2, Designation = "Engineer", Salary = 23000 });
            Add(new EmployeeToJoin() { EmpNo = 137, EmpName = "Anil", DeptNo = 9, Designation = "Intern", Salary = 8000 });
            Add(new EmployeeToJoin() { EmpNo = 138, EmpName = "Shyam", DeptNo = 8, Designation = "Engineer", Salary = 27000 });
            Add(new EmployeeToJoin() { EmpNo = 139, EmpName = "Vikram", DeptNo = 10, Designation = "Staff", Salary = 7000 });
            Add(new EmployeeToJoin() { EmpNo = 140, EmpName = "Suprotim", DeptNo = 7, Designation = "Engineer", Salary = 35000 });

            Add(new EmployeeToJoin() { EmpNo = 141, EmpName = "Mahesh", DeptNo = 3, Designation = "Intern", Salary = 11000 });
            Add(new EmployeeToJoin() { EmpNo = 142, EmpName = "Tejas", DeptNo = 6, Designation = "Engineer", Salary = 33000 });
            Add(new EmployeeToJoin() { EmpNo = 143, EmpName = "Nandu", DeptNo = 10, Designation = "Intern", Salary = 12000 });
            Add(new EmployeeToJoin() { EmpNo = 144, EmpName = "Anil", DeptNo = 1, Designation = "Staff", Salary = 14000 });
            Add(new EmployeeToJoin() { EmpNo = 145, EmpName = "Jaywant", DeptNo = 9, Designation = "Staff", Salary = 7000 });
            Add(new EmployeeToJoin() { EmpNo = 146, EmpName = "Abhay", DeptNo = 5, Designation = "Manager", Salary = 50000 });
            Add(new EmployeeToJoin() { EmpNo = 147, EmpName = "Anil", DeptNo = 4, Designation = "Intern", Salary = 9000 });
            Add(new EmployeeToJoin() { EmpNo = 148, EmpName = "Shyam", DeptNo = 8, Designation = "Engineer", Salary = 28000 });
            Add(new EmployeeToJoin() { EmpNo = 149, EmpName = "Vikram", DeptNo = 7, Designation = "Staff", Salary = 15000 });
            Add(new EmployeeToJoin() { EmpNo = 150, EmpName = "Suprotim", DeptNo = 2, Designation = "Engineer", Salary = 30000 });
        }   

    }
}
