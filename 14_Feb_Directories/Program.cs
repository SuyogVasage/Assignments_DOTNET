using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _14_Feb_Directories
{
    internal class Program
    {
        static DirectoryOp dirOp;
        static void Main(string[] args)
        {
            dirOp = new DirectoryOp();
            int a = 0;
            do
            {
                Console.WriteLine("\nPlease enter your choice number\n" +
                    "1) List all text files from Directory\n" +
                    "2) Read data from all files in Directory\n" +
                    "3) Read one file from Directory\n" +
                    "4) Read one particular line from file in Directory\n" +
                    "5) File Information\n" +
                    "6) Close the program\n");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("List of all Text Files from Directory\n");
                        dirOp.MyList();
                        break;
                    case 2:
                        Console.WriteLine("Data from all th files in Directory\n");
                        dirOp.ReadAllFiles();
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee number for salary slip (Between 101 to 150)");
                        int num = Convert.ToInt32(Console.ReadLine());
                        dirOp.ReadOneFile(num);
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee number for salary slip (Between 101 to 150)");
                        int num1 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter line number");
                        int num2 = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine($"Data in Line Number - {num2} is \n");
                        dirOp.ReadAnyLine(num1, num2);
                        break;
                    case 5:
                        //Console.WriteLine("Enter Employee number for salary slip file information (Between 101 to 150)");
                        //int num3 = Convert.ToInt32(Console.ReadLine());
                        dirOp.FileInfo();
                        break;
                    case 6:
                        a++;
                        break;
                    default:
                        Console.WriteLine("Please Enter Correct Choice Number");
                        break;
                }
            } while (a == 0); 
            
           // Console.ReadLine();

        }
    }
}
