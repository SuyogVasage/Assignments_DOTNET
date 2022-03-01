using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;

namespace Threading_26Feb
{
    internal class StoreData
    {
        public void WriteDateToDB(Employee employee)
        {
            SqlCommand cmd = null;
            SqlConnection conn = new SqlConnection(@"Data Source = SVASAGE-LAP-047\SQLEXPRESS; Initial Catalog = Industry; Integrated Security = SSPI");
            try
            {
                conn.Open();
                //var employee = GetEmpData();
                cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = $"Insert into Employee Values({employee.EmpNo}, '{employee.EmpName}', {employee.Salary}, '{employee.Designation}',{employee.DeptNo}, '{employee.Email}')";
                int res = cmd.ExecuteNonQuery();
                if (res == 0) { employee = null; }
                else { employee = new Employee(); Console.WriteLine("Data Added Successfully in Database!"); }
            }
            catch(SqlException ex) { Console.WriteLine(ex.Message); Thread.CurrentThread.Abort(); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { if (conn.State == ConnectionState.Open) { conn.Close(); } }

        }

        public void WriteDataToFile(Employee emp)
        {
            try
            {
               // var emp = GetEmpData();
                string path = @"C:\Users\Coditas\source\repos\Assignments\Employee_Data";
                string filePath = $@"{path}\Data-of-EmpNo-{emp.EmpNo}";
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"Specified File {filePath} is Already exists");
                    Thread.CurrentThread.Abort();
                }
                else
                {
                    FileStream fs = new FileStream($"{filePath}", FileMode.CreateNew);
                    BinaryFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(fs, emp);
                    Console.WriteLine("Data Added Successfully in File!");
                    fs.Close();
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            
        }

        public void GetDataFromDB(int id) 
        {
            SqlCommand cmd = null;
            SqlConnection conn = new SqlConnection(@"Data Source = SVASAGE-LAP-047\SQLEXPRESS; Initial Catalog = Industry; Integrated Security = SSPI");
            Employee employee = new Employee();
            try
            {
                conn.Open();
                cmd = new SqlCommand($"Select * from Employee where EmpNo = {id}", conn);
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    employee.EmpNo = Convert.ToInt32(Reader["EmpNo"]);
                    employee.EmpName = Reader["EmpName"].ToString();
                    employee.Salary = Convert.ToInt32(Reader["Salary"]);
                    employee.Designation = Reader["Designation"].ToString();
                    employee.DeptNo = Convert.ToInt32(Reader["DeptNo"]);
                    employee.Email = Reader["Email"].ToString();
                }
                Reader.Close();
            }
            catch (SqlException ex)
            {

                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            Console.WriteLine($"Data from Database\n" +
                $"{employee.EmpNo} {employee.EmpName}  {employee.Salary}  {employee.Designation}  {employee.DeptNo}  {employee.Email}\n");
        }
        public void GetDataFromFile(int EmpNo)
        {
            try
            {
               
                string path = @"C:\Users\Coditas\source\repos\Assignments\Employee_Data";
                FileStream fs = new FileStream($@"{path}\Data-of-EmpNo-{EmpNo}", FileMode.Open, FileAccess.Read);
                BinaryFormatter formatter = new BinaryFormatter();
                Employee emp = (Employee)formatter.Deserialize(fs);
                Console.WriteLine($"Data from File\n" +
                    $"EmpNo = {emp.EmpNo}\n" +
                    $"EmpName = {emp.EmpName}\n" +
                    $"DeptNo = {emp.DeptNo}\n" +
                    $"Salary = {emp.Salary}\n" +
                    $"Designation = {emp.Designation}\n" +
                    $"Email = {emp.Email}\n");
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
            //Parallel.Invoke(() =>
            //{
            //    WriteDataToFile(employee);
            //    WriteDateToDB(employee);
            ////}
            //);
            Thread t1 = new Thread(() => WriteDateToDB(employee));
            Thread t2 = new Thread(() => WriteDataToFile(employee));
            t1.Start();
            t2.Start();
            return employee;
        }

        public int GetEmpNo()
        {
            Console.WriteLine("\nEnter EmpNo to view Employee Details");
            int EmpNo = Convert.ToInt32(Console.ReadLine());
            //Parallel.Invoke(() =>
            //{
            //    GetDataFromDB(EmpNo);
            //    GetDataFromFile(EmpNo);
            //}
            //);
            Thread t1 = new Thread(() => GetDataFromDB(EmpNo));
            Thread t2 = new Thread(() => GetDataFromFile(EmpNo));
            t1.Start();
            t2.Start();
            return EmpNo;
        }
    }
}
