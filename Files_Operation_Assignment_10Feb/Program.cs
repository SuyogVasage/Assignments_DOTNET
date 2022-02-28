using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Files_Operation_Assignment_10Feb
{
    internal class Program
    {
        static Files_Operation fileOp;
        static void Main(string[] args)
        {
            fileOp = new Files_Operation();
            Employees employees = new Employees();
            foreach (Employee e in employees)
            {
                if (e.Designation == "Director")
                {
                    e.HRA = 0.2 * e.Salary;
                    e.TA = 0.3 * e.Salary;
                    e.DA = 0.4 * e.Salary;
                }
                if (e.Designation == "Manager ")
                {
                    e.HRA = 0.1 * e.Salary;
                    e.TA = 0.15 * e.Salary;
                    e.DA = 0.2 * e.Salary;
                }
                if (e.Designation == "Engineer")
                {
                    e.HRA = 0.05 * e.Salary;
                    e.TA = 0.1 * e.Salary;
                    e.DA = 0.15 * e.Salary;
                }
                else
                {
                    e.HRA = 0.01 * e.Salary;
                    e.TA = 0.05 * e.Salary;
                    e.DA = 0.1 * e.Salary;
                }
            }

            foreach (Employee e in employees)
            {
                e.Gross = e.Salary + e.HRA + e.TA + e.DA;
                if (e.Gross > 100000) { e.Tax = e.Gross * 0.3; }
                if (e.Gross >= 50000 && e.Gross <= 100000) { e.Tax = e.Gross * 0.2; }
                else { e.Tax = e.Gross * 0.1; }

                e.NetSalary = (int)e.Gross - (int)e.Tax;
            }

            //fileOp.WriteEmployeeSalarySlipParallel("February");
            fileOp.WriteEmployeeSalarySlipNonParallel(ref employees, "February");
            Console.ReadLine(); 
        }
    }
}
