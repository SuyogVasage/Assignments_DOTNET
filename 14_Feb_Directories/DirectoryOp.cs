using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _14_Feb_Directories
{

    internal class DirectoryOp
    {

        public void ReadOneFile(int EmployeeNo)
        {
            string filePath = $@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip\Salary-for-February, 2022-{EmployeeNo}.txt";
            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fs);
            string data = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine($"Data in file \"Salary-for-February, 2022 {EmployeeNo}.txt\"  is");
            Console.WriteLine(data);
            fs.Close();
        }

        public void ReadAnyLine(int EmployeeNo, int line)
        {
            using (var sr = new StreamReader($@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip\Salary-for-February, 2022-{EmployeeNo}.txt"))
            {
                for (int i = 1; i < line; i++)
                    sr.ReadLine();
                    Console.WriteLine(sr.ReadLine());
            }
        }
        /*
        public void ListAllFileFromDirectory() 
        {
            var files = Directory.GetFiles(@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip", "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Console.WriteLine(file);
                
            }
        }
        */

        public void ReadAllFiles()
        {
            var files = Directory.GetFiles(@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip", "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                Console.WriteLine(file);
                string filePath = $"{file}";
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fs);
                string data = reader.ReadToEnd();
                reader.Close();
                Console.WriteLine(data);
                fs.Close();

            }
        }

        public void FileInfo(int EmployeeNo)
        {
            string filePath = $@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip\Salary-for-February, 2022-{EmployeeNo}.txt";
            FileInfo fileInfo = new FileInfo(filePath);
            Console.WriteLine($"FileName = {fileInfo.Name}  |  Extension = {fileInfo.Extension}  |  Size = {fileInfo.Length} Bytes  |  Last Modified on {fileInfo.LastWriteTime} ");
        }


        public List<string> MyList()
        {
            List<string> mylist = new List<string>();
            var files = from file in Directory.GetFiles(@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip", "*.txt", SearchOption.AllDirectories)
                        select file.Substring(63);
            foreach (var file in files)
            {
                mylist.Add(file);
                Console.WriteLine(file);
            }
            return mylist;
        }
    }


    }


    /*
    internal class EmployeeFileData
    {
        //public List<EmployeeFile> listFile;
        
        //public List<EmployeeFile> EmpFile;
        public EmployeeFileData()
        {
            List<string> vs = new List<string>();
            var files = Directory.GetFiles(@"C:\Users\Coditas\source\repos\Assignment_1\Employee_SalarySlip", "*.txt", SearchOption.AllDirectories);

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                vs.Add(fileInfo.Name);
                //Add(new EmployeeFile() { FileName = fileInfo.Name, FileAddress = file});
            }

            
 
        }
        */

    
    


    

