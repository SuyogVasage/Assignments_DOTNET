//Clint class at last

/*public List<Employee> isValidEmpNo(List<Employee> emp, int emNo)
{
    int m = 0;
    do
    {
        for (int i = 0; i < Employees.Count; i++)
        {
            if (Employees[i].EmpNo == emNo)
            {
                Console.WriteLine("Please enter correct Employee No.");
                emNo = Convert.ToInt32(Console.ReadLine());
                m++;
            }
            else
            {
                emNo = Convert.ToInt32(Console.ReadLine());
                m = 0;
            }

        }
    } while (m > 0);
    return Employees;

}*/



//Employee operation class last

//Dictionary<string, List<Employee>> deptNameDictionary = new Dictionary<string, List<Employee>>();


//program at start

//Dictionary<string, List<Employee>> employeeDictionary = new Dictionary<string, List<Employee>>();

/*foreach (Employee employee in employees)
{
    employeeDictionary.Add(employee.DeptName, employees);
}*/



//EmpNo validation

//int emNo = employee.EmpNo;


/* 
            do
            {
                for (int i = 0; i < employees.Count; i++)
                {
                    if (employees[i].EmpNo == employee.EmpNo || employee.EmpNo <= 0)
                    {
                        Console.WriteLine("Please enter correct Employe No.");
                        employee.EmpNo = Convert.ToInt32(Console.ReadLine());
                        d++;
                    }
                    else
                    {
                        d = 0;
                    }
                } 
            } while (d > 0);*/


/*
                    /* if (employee.EmpNo >= 0)
                     {
                         d = 0;
                     }
                     else
                     {
                         Console.WriteLine("Please enter correct Employe No.");
                         employee.EmpNo = Convert.ToInt32(Console.ReadLine());
                         d++;
                     }*/



//Client Dict

/*public List<Employee> ListByDept1(List<Employee> emp)
{
    Dictionary<string, Employee> empDictionary = new Dictionary<string, Employee>();
    foreach (Employee employee in Employees)
    {
        foreach (var item in empDictionary)
        {
            empDictionary.Add(employee.DeptName, employee);
        }
    }
    foreach (Employee employee in Employees)
    {
        foreach (var item in empDictionary)
        {
            Console.WriteLine($"{employee.DeptName} {employee.EmpName}");
        }

    }
    return Employees;
}*/


//program last dict print

/*

        static void PrintValues(ref Dictionary<string, Employee> emps)
        {
                foreach (var item in emps)
                {
                    Console.WriteLine($"{item.Key} {item.Value.EmpNo} {item.Value.EmpName}\n");
                } 
        }
*/

//unnecessary directives

/*
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS_OOPSApp;
using MiniProject_EmployeeData;*/

///10 feb assignment tax salary

/*
 
 static void TaxSalary(ref Employees emps)
        {
            var TaxSalary1 = from e in emps
                             where e.Salary >= 20000 && e.Salary <= 40000
                             select e; 
            foreach (var item in TaxSalary1)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary} Tax = {item.Salary * 0.0005}");
            }
            Console.WriteLine("\n\n");
            var TaxSalary2 = from e in emps
                             where e.Salary >= 40000 && e.Salary <= 60000
                             select e;
            foreach (var item in TaxSalary2)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary} Tax = {item.Salary * 0.001}");
            }
            Console.WriteLine("\n\n");
            var TaxSalary3 = from e in emps
                             where e.Salary >= 60000
                             select e;
            foreach (var item in TaxSalary3)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary} Tax = {item.Salary * 0.0015}");
            }
            Console.WriteLine("\n\n");
            var TaxSalary4 = from e in emps
                             where e.Salary < 20000
                             select e;
            foreach (var item in TaxSalary4)
            {
                Console.WriteLine($"{item.EmpNo} {item.EmpName} {item.DeptName} {item.Designation} {item.Salary} Tax = 0");
            }
        }*/