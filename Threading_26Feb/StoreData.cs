using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Threading_26Feb
{
    internal class StoreData
    {
        public void WriteDateToDB()
        {
            SqlCommand cmd = null;
            SqlConnection conn = new SqlConnection(@"Data Source = SVASAGE-LAP-047\SQLEXPRESS; Initial Catalog = Industry; Integrated Security = SSPI");
            try
            {
                conn.Open();
                var employee = GetEmpData();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Insert into Employee Values({employee.EmpNo}, '{employee.EmpName}', {employee.Salary}, '{employee.Designation}',{employee.DeptNo}, '{employee.Email}')";
                int res = cmd.ExecuteNonQuery();
                if (res == 0) { employee = null; }
                else { employee = new Employee(); Console.WriteLine("Data Added Successfully !"); }
            }
            catch(SqlException ex) { Console.WriteLine(ex.Message); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }

        }

        public void WriteDataToFile()
        {
            try
            {
                var emp = GetEmpData();
                string path = @"C:\Users\Coditas\source\repos\Assignments\Employee_Data";
                string filePath = $@"{path}\Data-of-EmpNo-{emp.EmpNo}";
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Specified File {filePath} is Already exists");
                }
                else
                {
                    FileStream fs = new FileStream($"{filePath}", FileMode.CreateNew);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, emp);
                    Console.WriteLine("Data Added Successfully !");
                    fs.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public void GetDataFromFile()
        {
            try
            {
                Console.WriteLine("Enter EmpNo to view Employee Details");
                int EmpNo = Convert.ToInt32(Console.ReadLine());
                string path = @"C:\Users\Coditas\source\repos\Assignments\Employee_Data";
                FileStream fs = new FileStream($@"{path}\Data-of-EmpNo-{EmpNo}", FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                Employee emp = (Employee)formatter.Deserialize(fs);
                Console.WriteLine($"EmpNo = {emp.EmpNo}\n" +
                    $"EmpName = {emp.EmpName}\n" +
                    $"DeptNo = {emp.DeptNo}\n" +
                    $"Salary = {emp.Salary}\n" +
                    $"Designation = {emp.Designation}\n" +
                    $"Email = {emp.Email}");
                fs.Close();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public Employee GetEmpData()
        {
            Employee employee = new Employee();
            Console.WriteLine("Enter Employee Data\n");
            Console.WriteLine("Enter EmpNo");
            employee.EmpNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmpName");
            employee.EmpName = Console.ReadLine();
            Console.WriteLine("Enter DeptNo");
            employee.DeptNo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Salary");
            employee.Salary = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Designation");
            employee.Designation = Console.ReadLine();
            Console.WriteLine("Enter Email");
            employee.Email = Console.ReadLine();
            return employee;
        }
    }
}
