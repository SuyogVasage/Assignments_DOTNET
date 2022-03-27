using System.Linq;
using System;
using CS_ScalarFunctions.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

List<Employee> employees = new List<Employee>();
try
{
    ManageDatabase();

    var db = new PersonalInformationDB();

    employees.Add(new Employee() { EmpName = "Mahesh", DeptName = "IT", Designation = "Manager", Salary = 12000 });
    employees.Add(new Employee() { EmpName = "Ajay", DeptName = "HR", Designation = "Lead", Salary = 8000 });
    employees.Add(new Employee() { EmpName = "Kishore", DeptName = "SL", Designation = "Lead", Salary = 22000 });
    employees.Add(new Employee() { EmpName = "Abhay", DeptName = "IT", Designation = "Manager", Salary = 7000 });
    employees.Add(new Employee() { EmpName = "Anil", DeptName = "HR", Designation = "Lead", Salary = 32000 });
    employees.Add(new Employee() { EmpName = "Jaywant", DeptName = "SL", Designation = "Manager", Salary = 10000 });
    employees.Add(new Employee() { EmpName = "Shyam", DeptName = "IT", Designation = "Manager", Salary = 62000 });
    employees.Add(new Employee() { EmpName = "Ramesh", DeptName = "HR", Designation = "Lead", Salary = 4000 });
    employees.Add(new Employee() { EmpName = "Keshav", DeptName = "SL", Designation = "Manager", Salary = 34000 });
    employees.Add(new Employee() { EmpName = "Anil", DeptName = "SL", Designation = "Lead", Salary = 15000 });

    foreach (var emp in employees)
    {
        db.Employees.Add(emp);
    }
    db.SaveChanges();

    Console.WriteLine("Enter the DeptName");
    var dept = Console.ReadLine();
    //The string interpolation
    var res = db.Employees.FromSqlInterpolated($"Select * from Employees where DeptName={dept}");
    foreach (var item in res)
    {
        Console.WriteLine($"{item.EmpId} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
 
static void ManageDatabase()
{

    using (var ctx = new PersonalInformationDB())
    {
        ctx.Database.EnsureDeleted();
        ctx.Database.EnsureCreated();
    }
}