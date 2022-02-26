using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _22Feb_DB_EmpDep_by_disconnected
{
    internal class DepartmentDataAccess : IDataAccess<Department, int>
    {
        SqlConnection Conn;

        public DepartmentDataAccess() 
        {
            Conn = new SqlConnection(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Industry;Integrated Security=SSPI");
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");
        }

        DataSet Ds = new DataSet();

        void IDataAccess<Department, int>.Create()
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            DataRow DrNew = Ds.Tables["Department"].NewRow();
            Console.WriteLine("Enter DeptNo");
            DrNew["DeptNo"] = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter DeptName");
            DrNew["DeptName"] = Console.ReadLine();
            Console.WriteLine("Enter Location");
            DrNew["Location"] = Console.ReadLine();
            Console.WriteLine("Enter Capacity");
            DrNew["Capacity"] = Convert.ToInt32(Console.ReadLine());
            Ds.Tables["Department"].Rows.Add(DrNew);
            SqlCommandBuilder bldr1 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
            Console.WriteLine($"Department with Dept No.= {DrNew["DeptNo"]} is added successfully !");
        }

        void IDataAccess<Department, int>.Delete(int id)
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");
            DataRow DrFind = Ds.Tables["Department"].Rows.Find(id);
            DrFind.Delete();
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
            Console.WriteLine($"Department with Dept No.={id} is deleted successfully !");
        }

        void IDataAccess<Department, int>.GetData()
        {
            DataRowCollection dataRows = Ds.Tables["Department"].Rows;

            foreach (DataRow row in dataRows)
            {
                Console.WriteLine($"{row["DeptNo"]}     {row["DeptName"]}       {row["location"]}       {row["Capacity"]}");
                
            }
        }

        void IDataAccess<Department, int>.GetData(int id)
        {
            DataRow DrFind = Ds.Tables["Department"].Rows.Find(id);
            Console.WriteLine($"{DrFind["DeptNo"]}     {DrFind["DeptName"]}       {DrFind["location"]}       {DrFind["Capacity"]}");

        }

        void IDataAccess<Department, int>.Update(int id)
        {
            SqlDataAdapter AdDept = new SqlDataAdapter("Select * from Department", Conn);
            AdDept.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            AdDept.Fill(Ds, "Department");
            DataRow DrFind = Ds.Tables["Department"].Rows.Find(id);
            Console.WriteLine("Enter DeptName");
            DrFind["DeptName"] = Console.ReadLine();
            Console.WriteLine("Enter Location");
            DrFind["Location"] = Console.ReadLine();
            Console.WriteLine("Enter Capacity");
            DrFind["Capacity"] = Convert.ToInt32(Console.ReadLine());
            SqlCommandBuilder bldr2 = new SqlCommandBuilder(AdDept);
            AdDept.Update(Ds, "Department");
            Console.WriteLine($"Department with Dept No.={id} is updated successfully !");
        }
    }
}

