using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_March_CRUD_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDataAccess<Department, int> DeptDb = new DeptDbAccess();
                IDataAccess<Employee, int> EmpDb = new EmpDbAccess();
                int a = 0;
                do
                {
                    Console.WriteLine("\nEnter your Choice");
                    Console.WriteLine("1. View all departments\n" +
                        "2. Add Department\n" +
                        "3. Update Department\n" +
                        "4. Delete Department\n" +
                        "5. Search Department\n" +
                        "6. View all employees\n" +
                        "7. Add Employee\n" +
                        "8. Update Employee\n" +
                        "9. Delete Employee\n" +
                        "10. Search Employee\n" +
                        "11. Close the program\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            var DeptData = DeptDb.GetAsync().Result;
                            foreach (Department item in DeptData)
                            {
                                Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity}");
                            }
                            break;
                        case 2:
                            Department dept = new Department();
                            Console.WriteLine("Enter Department details");
                            Console.WriteLine("Enter Department number");
                            dept.DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Departname name");
                            dept.DeptName = Console.ReadLine();

                            Console.WriteLine("Enter Location");
                            dept.Location = Console.ReadLine();

                            Console.WriteLine("Enter Capacity");
                            dept.Capacity = Convert.ToInt32(Console.ReadLine());

                            DeptDb.CreateAsync(dept);
                            break;
                        case 3:
                            Department db1 = new Department();
                            Console.WriteLine("Enter Department Details To Update");
                            Console.WriteLine("Enter Department number");
                            db1.DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Departname name");
                            db1.DeptName = Console.ReadLine();

                            Console.WriteLine("Enter Location");
                            db1.Location = Console.ReadLine();

                            Console.WriteLine("Enter Capacity");
                            db1.Capacity = Convert.ToInt32(Console.ReadLine());

                            var e5 = DeptDb.UpdateAsync(db1.DeptNo, db1).Result;
                            if (e5 == 0)
                            { Console.WriteLine("Update Failed"); }
                            else { Console.WriteLine("Update Success"); }
                            break;
                        case 4:
                            Console.WriteLine("Enter Department number");
                            int num4 = Convert.ToInt32(Console.ReadLine());
                            var e4 = DeptDb.DeleteAsync(num4).Result;
                            if (e4 == 0) { Console.WriteLine("Wrong DeptNo"); }
                            else { Console.WriteLine($"DeptNo = {num4} is deleted "); }
                            break;
                        case 5:
                            Console.WriteLine("Enter Department number");
                            int num3 = Convert.ToInt32(Console.ReadLine());
                            var dept1 = DeptDb.GetAsync(num3).Result;
                            if(dept1 == null) { Console.WriteLine("Record Not Found"); }
                            else
                            {
                                Console.WriteLine($"{dept1.DeptNo} {dept1.DeptName} {dept1.Location} {dept1.Capacity}");
                            }
                            break;
                        case 6:
                            var EmpData = EmpDb.GetAsync().Result;
                            foreach (Employee item in EmpData)
                            {
                                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.Designation} {item.DeptNo} {item.Email}");
                            }
                            break;
                        case 7:
                            Employee empployee = new Employee(); 
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            empployee.EmpNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            empployee.EmpName = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            empployee.Salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            empployee.DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            empployee.Designation = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            empployee.Email = Console.ReadLine();

                            EmpDb.CreateAsync(empployee);
                            break;
                        case 8:
                            Employee employee = new Employee();
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            employee.EmpNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            employee.EmpName = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            employee.Salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            employee.DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            employee.Designation = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            employee.Email = Console.ReadLine();
                            var e = EmpDb.UpdateAsync(employee.EmpNo, employee).Result;
                            if (e == 0)
                            { Console.WriteLine("Update Failed"); }
                            else { Console.WriteLine("Update Success"); }
                            break;
                        case 9:
                            Console.WriteLine("Enter employee number");
                            int num1 = Convert.ToInt32(Console.ReadLine());
                            int e1 = EmpDb.DeleteAsync(num1).Result;
                            if (e1 == 0) { Console.WriteLine("Wrong EmpNo"); }
                            else { Console.WriteLine($"EmpNo = {num1} is deleted "); }
                            break;
                        case 10:
                            Console.WriteLine("Enter employee number");
                            int num = Convert.ToInt32(Console.ReadLine());
                            var emps = EmpDb.GetAsync(num).Result;
                            if (emps == null) { Console.WriteLine("Record Not Found"); }
                            else
                            {
                                Console.WriteLine($"{emps.EmpNo} {emps.EmpName} {emps.Salary} {emps.Designation} {emps.DeptNo} {emps.Email}");
                            }
                            break;
                        case 11:
                            a++;
                            break;
                        default:
                            Console.WriteLine("Please enter correct choice number");
                            break;
                    }
                } while (a == 0);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
