using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _18Feb_DB_Employee.Files;
namespace _18Feb_DB_Employee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IDataAccess<Employee, int> emp = new EmployeeDataAccess();
                IDataAccess2<Employee, string> emp1 = new Report();
                int a = 0;
                do
                {
                    Console.WriteLine("\nEnter your choice");
                    Console.WriteLine("1. View all employees\n" +
                        "2. Search employee by employee number\n" +
                        "3. Update employee details\n" +
                        "4. Delete employee details\n" +
                        "5. Add employee details\n" +
                        "6. List of employees by Department\n" +
                        "7. List of employees with maximum salary per Department\n" +
                        "8. Sum of salary by Department\n" +
                        "9. List employees by Location\n" +
                        "10. Close the program\n");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch(choice)
                    {
                        case 1:
                            var employees = emp.GetData();
                            foreach (Employee emps in employees)
                            {
                                Console.WriteLine($"{emps.EmpNo} {emps.EmpName} {emps.Salary} {emps.Designation} {emps.DeptNo} {emps.Email}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter employee number");
                            int num = Convert.ToInt32(Console.ReadLine());
                            var getemp = emp.GetData(num);
                            Console.WriteLine($"{getemp.EmpNo} {getemp.EmpName} {getemp.Salary} {getemp.Designation} {getemp.DeptNo} {getemp.Email}");
                            break;
                        case 3:
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            int EmpNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            string EmpName = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            int Salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            int DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            string Designation = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            string Email = Console.ReadLine();

                            var UpEmp = new Employee()
                            {
                                EmpNo = EmpNo,
                                EmpName = EmpName,
                                Salary = Salary,
                                DeptNo = DeptNo,
                                Designation = Designation,
                                Email = Email,
                            };
                            var result = emp.Update(EmpNo, UpEmp);
                            if (result == null) { Console.WriteLine("Failed to update data"); }
                            else { Console.WriteLine("Data updated successfully"); }
                            break;
                        case 4:
                            Console.WriteLine("Enter employee number");
                            int num1 = Convert.ToInt32(Console.ReadLine());
                            var resDelete = emp.Delete(num1);
                            break;
                        case 5:
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            int EmpNo1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            string EmpName1 = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            int Salary1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            int DeptNo1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            string Designation1 = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            string Email1 = Console.ReadLine();

                            var NewEmp = new Employee()
                            {
                                EmpNo = EmpNo1,
                                EmpName = EmpName1,
                                Salary = Salary1,
                                DeptNo = DeptNo1,
                                Designation = Designation1,
                                Email = Email1,
                            };
                            var result1 = emp.Create(NewEmp);
                            if (result1 == null) { Console.WriteLine("Failed to add data"); }
                            else { Console.WriteLine("Data added successfully"); }
                            break;
                        case 6:
                            Console.WriteLine("Enter the department whose employees you want to find");
                            string input = Console.ReadLine();
                            emp1.GetAllEmployeesByDeptName(input);
                            break;
                        case 7:
                            Console.WriteLine("Enter the department whose Max salary you want to find");
                            string inputDept = Console.ReadLine();
                            emp1.GetAllEmployeesWithMaxSalByDeptName(inputDept);
                            break;
                        case 8:
                            Console.WriteLine("Enter the department whose sum salary you want to find");
                            string inputDeptsum = Console.ReadLine();
                            emp1.GetSumSalaryByDeptName(inputDeptsum);
                            break;
                        case 9:
                            Console.WriteLine("Enter the location to search for employee");
                            string location = Console.ReadLine();
                            emp1.GetAllEmployeesByLocation(location);
                            break;
                        case 10:
                            a++;
                            break;
                        default:
                            break;

                    }
                }while (a == 0); 
               
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error Occured {ex.Message}");
            }
        }
    }
    
}
