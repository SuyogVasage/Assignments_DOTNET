using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace _2_March_SalarySlip_Async.Files
{
    internal class Operation
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
        public void WriteFiles()
        {
            Employees emps = new Employees();
            DateTime dateTime = DateTime.Now;
            int a = 0;
            var startTimerParallel = Stopwatch.StartNew();
            Parallel.For(0, emps.Count, (int i) =>
            {
                string path = @"C:\Users\Coditas\source\repos\Assignments\Employee_SalarySlip";
                string filePath = $@"{path}\Salary-for-{dateTime.ToString("Y")}-{emps[i].EmpNo}.txt";
                if (File.Exists(filePath))
                {
                    a = 1;
                }
                else
                {
                    if (emps[i].Designation == "Director")
                    {
                        emps[i].HRA = 0.2 * emps[i].Salary;
                        emps[i].TA = 0.3 * emps[i].Salary;
                        emps[i].DA = 0.4 * emps[i].Salary;
                    }
                    if (emps[i].Designation == "Manager ")
                    {
                        emps[i].HRA = 0.1 * emps[i].Salary;
                        emps[i].TA = 0.15 * emps[i].Salary;
                        emps[i].DA = 0.2 * emps[i].Salary;
                    }
                    if (emps[i].Designation == "Engineer")
                    {
                        emps[i].HRA = 0.05 * emps[i].Salary;
                        emps[i].TA = 0.1 * emps[i].Salary;
                        emps[i].DA = 0.15 * emps[i].Salary;
                    }
                    else
                    {
                        emps[i].HRA = 0.01 * emps[i].Salary;
                        emps[i].TA = 0.05 * emps[i].Salary;
                        emps[i].DA = 0.1 * emps[i].Salary;
                    }

                    emps[i].Gross = emps[i].Salary + emps[i].HRA + emps[i].TA + emps[i].DA;
                    if (emps[i].Gross > 100000) { emps[i].Tax = emps[i].Gross * 0.3; }
                    if (emps[i].Gross >= 50000 && emps[i].Gross <= 100000) { emps[i].Tax = emps[i].Gross * 0.2; }
                    else { emps[i].Tax = emps[i].Gross * 0.1; }

                    emps[i].NetSalary = (int)emps[i].Gross - (int)emps[i].Tax;
                    FileStream fs = new FileStream(filePath, FileMode.CreateNew);
                    BinaryFormatter formatter = new BinaryFormatter();

                    formatter.Serialize(fs,
                                     $"\n------------------Salary Slip for Month of February-------------------\n" +
                                     $"| Emp No -    {emps[i].EmpNo}        Emp Name -    {emps[i].EmpName}                      |\n" +
                                     $"| Dept Name - {emps[i].DeptName}    Designation - {emps[i].Designation}                   |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Income (Rs.)                | Deductions (Rs.)                      |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Basic Salary - {emps[i].Salary}       |                                       |\n" +
                                     $"| HRA -          {emps[i].HRA}         |                                       |\n" +
                                     $"| TA -           {emps[i].TA}         |                                       |\n" +
                                     $"| DA -           {emps[i].DA}        |                                       |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Gross -        {emps[i].Gross}       |                                       |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"|                            | Tax - {emps[i].Tax}                             |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Net Salary - {emps[i].NetSalary} Rs.                                            |\n" +
                                     $"-----------------------------------------------------------------------\n" +
                                     $"| Net Salary in Words - {NumberToWords(emps[i].NetSalary)} rupees    |\n" +
                                     $"-----------------------------------------------------------------------");
                    fs.Close();
                    Console.WriteLine($"Parallel Tax for Employee {emps[i].EmpNo} ");
                }
                i++;
            });
            if (a > 0) { Console.WriteLine($"Salary slip files are Already exists"); }
            else
            {
                Console.WriteLine("Employee salary slips stored successfully !" +
                "Press Enter to close Program");

                Console.WriteLine($"Parallel Process completed at {DateTime.Now}" +
                   $"Total Time {startTimerParallel.Elapsed.TotalSeconds}");
            }
        }
        public void moveFile()
        {
            string sourcePath = @"C:\Users\Coditas\source\repos\Assignments\Employee_SalarySlip";
            string targetPath = @"C:\Users\Coditas\source\repos\Assignments\Moved_salary_slip";
            int a = 0;
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath); 
                foreach (string s in files)
                {
                    
                    // Use static Path methods to extract only the file name from the path.
                    string fileName = System.IO.Path.GetFileName(s);
                    string temp = string.Empty;
                    temp = targetPath + "\\" + fileName;
                    if (File.Exists(temp))
                    {
                        a = 0;
                    }
                    else
                    {
                        string destFile = System.IO.Path.Combine(targetPath, fileName);
                        System.IO.File.Copy(s, destFile, true);
                        a++;
                    }
                }
                if (a > 0) { Console.WriteLine("Files Moved"); }
                else { Console.WriteLine("Files are already present"); }
               
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }
        }

    }
}
