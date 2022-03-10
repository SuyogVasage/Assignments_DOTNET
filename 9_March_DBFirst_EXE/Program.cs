using System.Text.Json;
using _9_March_DBFirst;
using _9_March_DBFirst.Models;

try
{
    IDataAccess<Department, int> deptDbAccess = new DepartmentDataAccess();
    IDataAccess<Employee, int> empDbAccess = new EmployeDataAccess();
    int a = 0;
    do
    {
        Console.WriteLine("\nEnter your Choice");
        Console.WriteLine("1. View all departments\n" +
            "2. Add Department\n" +
            "3. Update Department\n" +
            "4. Delete Department\n" +
            "5. View all employees\n" +
            "6. Add Employee\n" +
            "7. Update Employee\n" +
            "8. Delete Employee\n" +
            "9. Close the program\n" +
            "10. Clear Screen\n");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                var departments = await deptDbAccess.GetAsync();
                Console.WriteLine($"List of Depts\n" +
                    $"{JsonSerializer.Serialize(departments)}\n");
                break;
            case 2:
                Department newDept = new Department();
                Console.WriteLine("Enter Department details");
                Console.WriteLine("Enter Department number");
                newDept.DeptNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Departname name");
                newDept.DeptName = Console.ReadLine();

                Console.WriteLine("Enter Location");
                newDept.Location = Console.ReadLine();

                Console.WriteLine("Enter Capacity");
                newDept.Capacity = Convert.ToInt32(Console.ReadLine());

                var createdDept = await deptDbAccess.CreateAsync(newDept);
                Console.WriteLine($"Newly Added Dept" +
                    $"{JsonSerializer.Serialize(createdDept)}");
                break;
            case 3:
                Department updateDept = new Department();
                Console.WriteLine("Enter Department Details To Update");
                Console.WriteLine("Enter Department number");
                updateDept.DeptNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Departname name");
                updateDept.DeptName = Console.ReadLine();

                Console.WriteLine("Enter Location");
                updateDept.Location = Console.ReadLine();

                Console.WriteLine("Enter Capacity");
                updateDept.Capacity = Convert.ToInt32(Console.ReadLine());

                var updatededDept = await deptDbAccess.UpdateAsync(updateDept.DeptNo, updateDept);
                Console.WriteLine($"Updated Dept" +
                    $"{JsonSerializer.Serialize(updatededDept)}");
                break;
            case 4:
                Department DeleteDept = new Department();
                Console.WriteLine("Enter Department number");
                DeleteDept.DeptNo = Convert.ToInt32(Console.ReadLine());
                var res = await deptDbAccess.DeleteAsync(DeleteDept.DeptNo);
                Console.WriteLine($"Deleted Dept" +
                    $"{JsonSerializer.Serialize(res)}");
                break;
            case 5:
                var employees = await empDbAccess.GetAsync();
                Console.WriteLine($"List of Emps\n" +
                    $"{JsonSerializer.Serialize(employees)}\n");
                break;
            case 6:
                Employee emp = new Employee();
                Console.WriteLine("Enter employee details");
                Console.WriteLine("Enter employee number");
                emp.EmpNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee name");
                emp.EmpName = Console.ReadLine();

                Console.WriteLine("Enter employee salary");
                emp.Salary = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee department number");
                emp.DeptNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee designation");
                emp.Designation = Console.ReadLine();

                Console.WriteLine("Enter employee Email ID");
                emp.Email = Console.ReadLine();

                var createEmp = await empDbAccess.CreateAsync(emp);
                Console.WriteLine($"Newly Added Employee" +
                    $"{JsonSerializer.Serialize(createEmp)}");
                break;
            case 7:
                Employee emp1 = new Employee();
                Console.WriteLine("Enter employee details");
                Console.WriteLine("Enter employee number");
                emp1.EmpNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee name");
                emp1.EmpName = Console.ReadLine();

                Console.WriteLine("Enter employee salary");
                emp1.Salary = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee department number");
                emp1.DeptNo = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter employee designation");
                emp1.Designation = Console.ReadLine();

                Console.WriteLine("Enter employee Email ID");
                emp1.Email = Console.ReadLine();

                var updateEmp = await empDbAccess.UpdateAsync(emp1.DeptNo, emp1);
                Console.WriteLine($"Updated Dept" +
                    $"{JsonSerializer.Serialize(updateEmp)}");
                break;
            case 8:
                Employee deleteEmp = new Employee();
                Console.WriteLine("Enter Department number");
                deleteEmp.DeptNo = Convert.ToInt32(Console.ReadLine());
                var res1 = await empDbAccess.DeleteAsync(deleteEmp.DeptNo);
                Console.WriteLine($"Deleted Dept" +
                    $"{JsonSerializer.Serialize(res1)}");
                break;
            case 9:
                a++;
                break;
            case 10:
                Console.Clear();
                break;
            default:
                Console.WriteLine("Please Enter Correct Choice Number");
                break;
        }
    } while (a == 0);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
