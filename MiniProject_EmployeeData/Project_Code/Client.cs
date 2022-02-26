using System;
using System.Collections.Generic;

namespace MiniProject_EmployeeData
{
    internal class Client
    {
        EmployeeOpeartions operation = new EmployeeOpeartions();
        List<Employee> Employees = new List<Employee>();

        //Method for writing an Employee

        public List<Employee> GetEmployees()
        {
            return Employees;
        }

        //Method for Adding an Employee

        public List<Employee> AddEmployee(Employee emp)
        {
            Employees.Add(emp);
            return Employees;
        }

        //Method for Updating an Employee

        public List<Employee> UpdateEmployee(List<Employee> emp, int emNo, string updateName, string updateDept, string updateDesignation, int updateSalary)
        {
            try
            {
                Employees = emp;
                foreach (Employee employee in Employees)
                {
                    if (employee.EmpNo == emNo)
                    {
                        employee.EmpName = updateName;
                        employee.DeptName = updateDept;
                        employee.Designation = updateDesignation;
                        employee.Salary = updateSalary;
                        return Employees;
                    }
                }
                throw new Exception($"Employee with EmpNo = {emNo} does not exist, Please enter correct EmpNo");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Employees;
            }

        }

        //Method for Deleting an Employee

        public List<Employee> DeleteEmployee(List<Employee> emp, int emNo)
        {
            try
            {
                Employees = emp;
                foreach (Employee employee in Employees)
                {
                    if (employee.EmpNo == emNo)
                    {
                        Employees.Remove(employee);
                        Console.WriteLine($"Employee with EmpNo = {emNo} has been deleted from database.");
                        return Employees;
                    }

                }

                throw new Exception($"Employee with EmpNo = {emNo} does not exist, Please enter correct EmpNo");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Employees;
            }

        }

        //Method for Searching an Employee

        public List<Employee> SearchEmployee(List<Employee> emp, int emNo)
        {
            try
            {
                Employees = emp;
                foreach (Employee employee in Employees)
                {
                    if (employee.EmpNo == emNo)
                    {
                        Console.WriteLine($"\nEmpNo = {employee.EmpNo}\nEmpName = {employee.EmpName}\nDeptName = {employee.DeptName}\nDesignation = {employee.Designation}\nSalary = {employee.Salary}\n");
                        return Employees;

                    }
                }

                throw new Exception($"Employee with EmpNo = {emNo} does not exist");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Employees;
            }

        }

        //Method for Listing Employee bt Department

        public List<Employee> ListByDept(List<Employee> emp, string Dept)
        {
            Employees = emp;
            foreach (Employee employee in Employees)
            {
                if (employee.DeptName == "IT") { if (employee.DeptName == Dept) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }//{employee.DeptName} :- 
                else if (employee.DeptName == "HR") { if (employee.DeptName == Dept) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.DeptName == "Sales") { if (employee.DeptName == Dept) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.DeptName == "Admin") { if (employee.DeptName == Dept) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.DeptName == "Staff") { if (employee.DeptName == Dept) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }

            }
            return Employees;
        }

        //Method for Listing Employee bt Designation

        public List<Employee> ListByPost(List<Employee> emp, string Desig)
        {
            Employees = emp;
            foreach (Employee employee in Employees)
            {
                if (employee.Designation == "Intern") { if (employee.Designation == Desig) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } } //{employee.Designation} :- 
                else if (employee.Designation == "Manager") { if (employee.Designation == Desig) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.Designation == "Engineer") { if (employee.Designation == Desig) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.Designation == "Clerk") { if (employee.Designation == Desig) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }
                else if (employee.Designation == "Staff") { if (employee.Designation == Desig) { Console.WriteLine($"{employee.EmpNo} >> {employee.EmpName}"); } }

            }
            return Employees;
        }



    }

}
