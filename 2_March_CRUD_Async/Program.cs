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
                Employee emp = new Employee();
                DbOperartion dbOperartion = new DbOperartion();
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
                            var DeptData = dbOperartion.GetDeptDataAsync().Result;
                            foreach (Department item in DeptData)
                            {
                                Console.WriteLine($"{item.DeptNo} {item.DeptName} {item.Location} {item.Capacity}");
                            }
                            break;
                        case 2:
                            Console.WriteLine("Enter Department details");
                            Console.WriteLine("Enter Department number");
                            int DeptNo1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Departname name");
                            string DeptName12 = Console.ReadLine();

                            Console.WriteLine("Enter Location");
                            string Location1 = Console.ReadLine();

                            Console.WriteLine("Enter Capacity");
                            int Capacity1 = Convert.ToInt32(Console.ReadLine());

                            var NewDept = new Department()
                            {
                               DeptNo = DeptNo1,
                               DeptName = DeptName12,
                               Location = Location1,
                               Capacity = Capacity1,

                            };
                            dbOperartion.CreateDeptDataAsync(NewDept);
                            break;
                        case 3:
                            Console.WriteLine("Enter Department details");
                            Console.WriteLine("Enter Department number");
                            int DeptNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Departname name");
                            string DeptName = Console.ReadLine();

                            Console.WriteLine("Enter Location");
                            string Location = Console.ReadLine();

                            Console.WriteLine("Enter Capacity");
                            int Capacity = Convert.ToInt32(Console.ReadLine());

                            var NewDept1 = new Department()
                            {
                                DeptNo = DeptNo,
                                DeptName = DeptName,
                                Location = Location,
                                Capacity = Capacity,

                            };
                            dbOperartion.UpdateDeptDataAsync(NewDept1, DeptNo); 
                            break;
                        case 4:
                            Console.WriteLine("Enter Department number");
                            int num4 = Convert.ToInt32(Console.ReadLine());
                            dbOperartion.DeleteDeptDataAsync(num4);
                            break;
                        case 5:
                            Console.WriteLine("Enter Department number");
                            int num3 = Convert.ToInt32(Console.ReadLine());
                            var dept = dbOperartion.GetDeptDataAsync(num3).Result;
                            Console.WriteLine($"{dept.DeptNo} {dept.DeptName} {dept.Location} {dept.Capacity}");
                            break;
                        case 6:
                            var EmpData = dbOperartion.GetEmpDataAsync().Result;
                            foreach (Employee item in EmpData)
                            {
                                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.Salary} {item.Designation} {item.DeptNo} {item.Email}");
                            }
                            break;
                        case 7:
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            int EmpNo1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            string EmpName1 = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            int Salary1 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            int DeptNo12 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            string Designation1 = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            string Email1 = Console.ReadLine();

                            var NewEmp = new Employee()
                            {
                                EmpNo = EmpNo1,
                                EmpName = EmpName1,
                                Salary = Salary1,
                                DeptNo = DeptNo12,
                                Designation = Designation1,
                                Email = Email1,
                            };
                            dbOperartion.CreateEmpDataAsync(NewEmp);
                            break;
                        case 8:
                            Console.WriteLine("Enter employee details");
                            Console.WriteLine("Enter employee number");
                            int EmpNo = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee name");
                            string EmpName = Console.ReadLine();

                            Console.WriteLine("Enter employee salary");
                            int Salary = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee department number");
                            int DeptNo3 = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter employee designation");
                            string Designation = Console.ReadLine();

                            Console.WriteLine("Enter employee Email ID");
                            string Email = Console.ReadLine();

                            var UpEmp = new Employee()
                            {
                                EmpNo = EmpNo,
                                EmpName = EmpName,
                                Salary = Salary,
                                DeptNo = DeptNo3,
                                Designation = Designation,
                                Email = Email,
                            };
                            dbOperartion.UpdateEmpDataAsync(UpEmp, EmpNo);
                            break;
                        case 9:
                            Console.WriteLine("Enter employee number");
                            int num1 = Convert.ToInt32(Console.ReadLine());
                            dbOperartion.DeleteEmpDataAsync(num1);
                            break;
                        case 10:
                            Console.WriteLine("Enter employee number");
                            int num = Convert.ToInt32(Console.ReadLine());
                            var emps = dbOperartion.GetEmpDataAsync(num).Result;
                            Console.WriteLine($"{emps.EmpNo} {emps.EmpName} {emps.Salary} {emps.Designation} {emps.DeptNo} {emps.Email}");
                            break;
                        case 11:
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
