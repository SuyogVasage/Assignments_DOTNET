using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _22Feb_DB_EmpDep_by_disconnected.DataAccess
{
    internal class EmployeeDataAccess : IDataAccess<Employee, int>
    {
        SqlConnection Conn;
        

        public EmployeeDataAccess()
        {
            Conn = new SqlConnection(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Industry;Integrated Security=SSPI");
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Employee", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Employee");
        }

        //SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Employee", Conn);

        DataSet Ds = new DataSet();

        void IDataAccess<Employee, int>.Create()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Employee", Conn);
            DataRow DrNew = Ds.Tables["Employee"].NewRow();
            Console.WriteLine("Enter EmpNo");
            DrNew["EmpNo"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter EmpName");
            DrNew["EmpName"] = Console.ReadLine();
            Console.WriteLine("Enter Salary");
            DrNew["Salary"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Designation");
            DrNew["Designation"] = Console.ReadLine();
            Console.WriteLine("Enter DeptNo");
            DrNew["DeptNo"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email");
            DrNew["Email"] = Console.ReadLine();
            Ds.Tables["Employee"].Rows.Add(DrNew);
            SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Employee");
            Console.WriteLine($"Employee with Emp No.= {DrNew["EmpNo"]} is added successfully !");
        }

        void IDataAccess<Employee, int>.Delete(int id)
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Employee", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Employee");
            DataRow DrFind = Ds.Tables["Employee"].Rows.Find(id);
            DrFind.Delete();
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Employee");
            Console.WriteLine($"Employee with Emp No.={id} is deleted successfully !");
        }

        void IDataAccess<Employee, int>.GetData()
        {

            DataRowCollection dataRows = Ds.Tables["Employee"].Rows;

            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["EmpNo"]}     {row["EmpName"]}       {row["Salary"]}       {row["Designation"]}      {row["DeptNo"]}    {row["Email"]}");

            }
        }

        void IDataAccess<Employee, int>.GetData(int id)
        {

            DataRow DrFind = Ds.Tables["Employee"].Rows.Find(id);
            Console.WriteLine($"{DrFind["EmpNo"]}     {DrFind["EmpName"]}       {DrFind["Salary"]}       {DrFind["Designation"]}      {DrFind["DeptNo"]}    {DrFind["Email"]}");
        }

        void IDataAccess<Employee, int>.Update(int id)
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Employee", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Employee");
            DataRow DrFind = Ds.Tables["Employee"].Rows.Find(id);
            Console.WriteLine("Enter EmpName");
            DrFind["EmpName"] = Console.ReadLine();
            Console.WriteLine("Enter Salary");
            DrFind["Salary"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Designation");
            DrFind["Designation"] = Console.ReadLine();
            Console.WriteLine("Enter DeptNo");
            DrFind["DeptNo"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Email");
            DrFind["Email"] = Console.ReadLine();
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Employee");
            Console.WriteLine($"Employee with Emp No.={id} is updated successfully !");
        }
    }
}
