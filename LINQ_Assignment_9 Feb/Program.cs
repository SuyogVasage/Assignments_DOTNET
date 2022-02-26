using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment_9_Feb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees employees = new Employees();
            EmployeesToJoin employeeToJoins = new EmployeesToJoin();
            Departments departments = new Departments();
            int count = 0;
            do
            {
                Console.WriteLine("\nPlease enter your choice number");
                Console.WriteLine("1 - All Employees In Ascending Order by Employee Name" +
                    "\n2 - All Employees Group by the DeptName, and also display Employee Count for each DeptName" +
                    "\n3 - Salary Operations" +
                    "\n4 - All Employees by Designation Group" +
                    "\n5 - All Employees those are Managers, Directors only" +
                    "\n6 - Tax for Each Employee" +
                    "\n7 - Join Employees with Department using DeptNo" +
                    "\n8 - Close Program\n");
                int entry = Convert.ToInt32(Console.ReadLine());
                switch (entry)
                {
                    case 1:
                        Console.WriteLine("Ascending Order by Employee Name\n");
                        var orderByEmpName = employees.OrderBy(e => e.EmpName);
                        PrintResult(orderByEmpName);
                        break;
                    case 2:
                        Console.WriteLine("Group By Department\n");
                        var groupByDeptName = employees.GroupBy(e => e.DeptName);
                        foreach (var item in groupByDeptName)
                        {
                            Console.WriteLine(item.Key);
                            PrintResult(item.ToList());
                            Console.WriteLine($"The number of Employees in {item.Key} are {item.Count()}\n");
                        }
                        break;
                    case 3:
                        SalaryOperations(ref employees);
                        break;
                    case 4:
                        var groupByDesignation = employees.GroupBy(e => e.Designation);
                        Console.WriteLine("Group By Designation");
                        foreach (var item in groupByDesignation)
                        {
                            Console.WriteLine(item.Key);
                            PrintResult(item.ToList());
                        }
                        break;
                    case 5:
                        Console.WriteLine("Only Managers and Directors");
                        var TopEmployee = from e in employees
                                          where e.Designation == "Manager" || e.Designation == "Director"
                                          select e;
                        PrintResult(TopEmployee);
                        break;
                    case 6:
                        TaxOnSalary(ref employees);
                        break;
                    case 7:
                        JoinDeptToEmp(ref employeeToJoins, ref departments);
                        break;
                    case 8: 
                        count++;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Number");
                        break;
                }
            } while (count == 0);

        }

        static void TaxOnSalary(ref Employees emps)
        {
            var DeptGroup = (from e in emps
                                group e by e.DeptName into deptGroup
                                select new
                                {
                                    DeptName = deptGroup.Key,
                                    Records = deptGroup.ToList()
                                });
            foreach (var emp in DeptGroup)
            {
                Console.WriteLine($"\nDepartment - {emp.DeptName}");
                foreach (var temp in emp.Records)
                {
                    double tax = 0;
                    if (temp.Salary >= 20000 && temp.Salary <= 40000)
                    {
                        tax = temp.Salary * 0.0005;
                        Console.WriteLine($"{temp.EmpNo} {temp.EmpName} {temp.Designation} {temp.Salary} Tax = {Math.Round(tax)}");
                    }
                    if (temp.Salary > 40000 && temp.Salary <= 60000)
                    {
                        tax = temp.Salary * 0.001;
                        Console.WriteLine($"{temp.EmpNo} {temp.EmpName} {temp.Designation} {temp.Salary} Tax = {Math.Round(tax)}");
                    }
                    if (temp.Salary > 60000)
                    {
                        tax = temp.Salary * 0.0015;
                        Console.WriteLine($"{temp.EmpNo} {temp.EmpName} {temp.Designation} {temp.Salary} Tax = {Math.Round(tax)}");
                    }
                    else
                    {
                        Console.WriteLine($"{temp.EmpNo} {temp.EmpName} {temp.Designation} {temp.Salary} Tax = {Math.Round(tax)}");
                    }
                }
            }
        }
        

        static void JoinDeptToEmp(ref EmployeesToJoin emps, ref Departments depts)
        {
            var join = from e in emps  // Imperative Joining
                       join dept in depts
                       on e.DeptNo equals dept.DeptNo
                       select new
                       {
                           EmpNo = e.EmpNo,
                           EmpName = e.EmpName,
                           Designation = e.Designation,
                           DeptName = dept.DeptName,
                           Location = dept.Location,
                           Salary = e.Salary
                       };

            foreach (var j in join)
            {
                Console.WriteLine($"{j.EmpNo}  {j.EmpName}  {j.Designation}  {j.DeptName}  {j.Location}  {j.Salary}");
            }
        }

        static void SalaryOperations(ref Employees emps)
        { 
            var res = (from e in emps
                       group e by e.DeptName into deptgroup
                       select new
                       {
                           DeptName = deptgroup.Key,
                           SumSalary = deptgroup.Sum(x => x.Salary),
                           MaxSalary = deptgroup.GroupBy(e => e.Salary).OrderByDescending(x => x.Key).Take(1).SelectMany(s => s).ToList(),
                           MinSalary = deptgroup.GroupBy(e => e.Salary).OrderBy(x => x.Key).Take(1).SelectMany(s => s).ToList(),
                           AvgSalary = deptgroup.Average(x => x.Salary),
                           SecondMaxSalDept = deptgroup.GroupBy(e => e.Salary).OrderByDescending(x => x.Key).Skip(1).Take(1).SelectMany(s => s).ToList()
                       });
            int count = 0;
            do
            {
                Console.WriteLine("\n1 - Sum of Salary for Employess per DeptName" +
                           "\n2 - Employee with Maximum Salary Per DeptName" +
                           "\n3 - Employee with Minimum Salary Per DeptName" +
                           "\n4 - Average Salary Per DeptName" +
                           "\n5 - Employee with Second Maximum Salary Per DeptName" +
                           "\n6 - Employee with Second Max Salary" +
                           "\n7 - Employees Having Salary in Range 25000 to 75000" +
                           "\n8 - Close salary operation program\n");
                int i = Convert.ToInt32(Console.ReadLine());
                switch (i)
                {
                    case 1:
                        foreach (var record in res) { Console.WriteLine($"Department = {record.DeptName} and Sum of Salary {record.SumSalary}"); }
                        break;
                    case 2:
                        foreach (var record in res)
                        {
                            Console.WriteLine($"\nHighest salary in {record.DeptName}\n");
                            PrintResult(record.MaxSalary);
                        }
                        break;
                    case 3:
                        foreach (var record in res)
                        {
                            Console.WriteLine($"\nLowest salary in {record.DeptName}\n");
                            PrintResult(record.MinSalary);
                        }
                        break;
                    case 4:
                        foreach (var record in res)
                        {
                            Console.WriteLine($"Department = {record.DeptName} have Average Salary {record.AvgSalary}");
                        }
                        break;
                    case 5:
                        foreach (var record in res)
                        {
                            Console.WriteLine($"\nSecond Highest salary in {record.DeptName}\n");
                            PrintResult(record.SecondMaxSalDept);
                        }
                        break;
                    case 6:
                        Console.WriteLine("Second Max Salary from all employees");
                        var SecondMaxSalary = emps.GroupBy(e => e.Salary).OrderByDescending(x => x.Key).Skip(1).Take(1).SelectMany(s => s).ToList();
                        PrintResult(SecondMaxSalary);
                        break;
                    case 7:
                        Console.WriteLine("Employee with salary in between 25000 to 75000");
                        var uptoSalary = from e in emps
                                         where e.Salary >= 25000 && e.Salary <= 75000
                                         select e;
                        PrintResult(uptoSalary);
                        break;
                    case 8:
                        count++;
                        break;
                    default:
                        Console.WriteLine("Enter Correct Number");
                        break;
                }

            } while (count == 0);
        }

        static void PrintResult(IEnumerable<Employee> emps)
        {
            foreach (var item in emps)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary}");
            }
        }
    }  
    
}
