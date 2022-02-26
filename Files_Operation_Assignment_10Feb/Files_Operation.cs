using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Files_Operation_Assignment_10Feb
{
    
    internal class Files_Operation
    {
        public static string NumberToWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + NumberToWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000000) > 0)
            {
                words += NumberToWords(number / 1000000000) + " billion ";
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words += NumberToWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += " ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
        public void WriteEmployeeSalarySlip(ref Employees emps, string month)
        {
            DateTime dateTime = DateTime.Now;
            int a = 0;
            foreach (var emp in emps)
            {
                string path = @"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip";
                string filePath = $@"{path}\Salary-for-{dateTime.ToString("Y")}-{emp.EmpNo}.txt";
                if (File.Exists(filePath))
                {
                    //Console.WriteLine($"Specified File {filePath} is Already exists");
                    a = 1;
                }
                else
                {
                    FileStream fs = new FileStream(filePath, FileMode.CreateNew); // FileMode.OpenOrCreate, FileAccess.Write
                    BinaryFormatter formatter = new BinaryFormatter();
                    
                    formatter.Serialize(fs,
                                     $"\n------------------Salary Slip for Month of {month}-------------------\n" +
                                     $"| Emp No -    {emp.EmpNo}        Emp Name -    {emp.EmpName}                      |\n" +
                                     $"| Dept Name - {emp.DeptName}    Designation - {emp.Designation}                   |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Income (Rs.)                | Deductions (Rs.)                      |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Basic Salary - {emp.Salary}       |                                       |\n" +
                                     $"| HRA -          {emp.HRA}         |                                       |\n" +
                                     $"| TA -           {emp.TA}         |                                       |\n" +
                                     $"| DA -           {emp.DA}        |                                       |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Gross -        {emp.Gross}       |                                       |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"|                            | Tax - {emp.Tax}                             |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Net Salary - {emp.NetSalary} Rs.                                            |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Net Salary in Words - {NumberToWords(emp.NetSalary)} rupees    |\n" +
                                     $"-----------------------------------------------------------------------");
                    //formatter.Serialize(fs, empp);

                    

                    /*StreamWriter writer = new StreamWriter(fs);
                    writer.WriteLine($"\n------------------Salary Slip for Month of {month}----------------\n" +
                                     $"| Emp No -    {emp.EmpNo}        Emp Name - {emp.EmpName}        |\n" +
                                     $"| Dept Name - {emp.DeptName}     Designation - {emp.Designation} |\n" +
                                     $"------------------------------------------------------------------\n" +
                                     $"| Income (Rs.)                | Deductions (Rs.)                 |\n" +
                                     $"------------------------------------------------------------------\n" +
                                     $"| Basic Salary - {emp.Salary}    |                               |\n" +
                                     $"| HRA -          {emp.HRA}      |                               |\n" +
                                     $"| TA -           {emp.TA}      |                               |\n" +
                                     $"| DA -           {emp.DA}     |                               |\n" +
                                     $"---------------------------------------------------------------\n" +
                                     $"| Gross -        {emp.Gross}  |                               |\n" +
                                     $"---------------------------------------------------------------\n" +
                                     $"|                             | Tax - {emp.Tax}               |\n" +
                                     $"---------------------------------------------------------------\n" +
                                     $"| Net Salary - {emp.NetSalary} Rs.                            |\n" +
                                     $"---------------------------------------------------------------\n" +
                                     $"| Net Salary in Words - {NumberToWords(emp.NetSalary)} rupees |\n" +
                                     $"---------------------------------------------------------------");*/
                    //writer.Close();
                    fs.Close();
                    //fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                   // Employee emp1 = (Employee)formatter.Deserialize(fs);
                    /*Console.WriteLine($"" +
                   $"EmpNo: {emp1.EmpNo}, EmpName: {emp1.EmpName}, " +
                   $"DeptName: {emp1.DeptName}," +
                   $"Designation: {emp1.Designation}, Salary: {emp1.Salary}");
                    fs.Close();*/
                }
            }

            if (a > 0) { Console.WriteLine($"Salary slip files are Already exists"); }
            else
            {
                Console.WriteLine("Employee salary slips stored successfully !" +
            "Press Enter to close Program");
            }
           
        }
    }
}
