using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _22Feb_DB_EmpDep_by_disconnected.DataAccess;

namespace _22Feb_DB_EmpDep_by_disconnected
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            try
            {
                IDataAccess<Department, int> dept = new DepartmentDataAccess();
                IDataAccess<Employee, int> emp = new EmployeeDataAccess();
                int a = 0;
                do
                {
                    Console.WriteLine("\nEnter your choice");
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
                    switch (choice)
                    {
                        case 1:
                            dept.GetData();
                            break;
                        case 2:
                            dept.Create();
                            break;
                        case 3:
                            Console.WriteLine("Enter Department number to update details");
                            int DeptNo = Convert.ToInt32(Console.ReadLine());
                            dept.Update(DeptNo);
                            break;
                        case 4:
                            Console.WriteLine("Enter Department number to delete");
                            int DeptNo1 = Convert.ToInt32(Console.ReadLine());
                            dept.Delete(DeptNo1);
                            break;
                        case 5:
                            Console.WriteLine("Enter Department number to search");
                            int DeptNo2 = Convert.ToInt32(Console.ReadLine());
                            dept.GetData(DeptNo2);
                            break;
                        case 6:
                            emp.GetData();
                            break;
                        case 7:
                            emp.Create();
                            break;
                        case 8:
                            Console.WriteLine("Enter Employee number to update details");
                            int EmpNo = Convert.ToInt32(Console.ReadLine());
                            emp.Update(EmpNo);
                            break;
                        case 9:
                            Console.WriteLine("Enter Department number to delete");
                            int EmpNo1 = Convert.ToInt32(Console.ReadLine());
                            emp.Delete(EmpNo1);
                            break;
                        case 10:
                            Console.WriteLine("Enter Department number to search");
                            int EmpNo2 = Convert.ToInt32(Console.ReadLine());
                            emp.GetData(EmpNo2);
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
                Console.WriteLine($"Error Occured {ex.Message}");
            }
        }
    }
}
