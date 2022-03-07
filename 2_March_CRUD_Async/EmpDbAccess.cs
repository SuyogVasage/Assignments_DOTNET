using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2_March_CRUD_Async
{
    internal class EmpDbAccess : IDataAccess<Employee, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public EmpDbAccess() 
        {
            Conn = new SqlConnection(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Industry;Integrated Security=SSPI");
        }
        async Task IDataAccess<Employee, int>.CreateAsync(Employee entity)
        {
            try
            {
                Employee emp = null;
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Employee Values({entity.EmpNo}, '{entity.EmpName}', {entity.Salary}, '{entity.Designation}', {entity.DeptNo}, '{entity.Email}')";

                int res = await Cmd.ExecuteNonQueryAsync(); //executes the sql query and returns number of rows affected

                if (res == 0)
                {
                    emp = null;
                }
                else
                {
                    emp = new Employee();
                    emp = entity;
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }

        async Task<int> IDataAccess<Employee, int>.DeleteAsync(int id)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete From Employee where EmpNo=@EmpNo";
                SqlParameter pEmpNo = new SqlParameter();
                pEmpNo.ParameterName = "@EmpNo";
                pEmpNo.SqlDbType = SqlDbType.Int;
                pEmpNo.Direction = ParameterDirection.Input;
                pEmpNo.Value = id;
                Cmd.Parameters.Add(pEmpNo);
                int res = await Cmd.ExecuteNonQueryAsync();

                Conn.Close();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }

        async Task<IEnumerable<Employee>> IDataAccess<Employee, int>.GetAsync()
        {
            List<Employee> emps = new List<Employee>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Employee";
                SqlDataReader EmpData = await Cmd.ExecuteReaderAsync();

                while (EmpData.Read())
                {
                    emps.Add(new Employee()
                    {
                        EmpNo = Convert.ToInt32(EmpData["EmpNo"]),
                        EmpName = EmpData["EmpName"].ToString(),
                        Salary = Convert.ToInt32(EmpData["Salary"]),
                        Designation = EmpData["Designation"].ToString(),
                        DeptNo = Convert.ToInt32(EmpData["DeptNo"]),
                        Email = EmpData["Email"].ToString(),
                    });
                }
                EmpData.Close();
                Conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
            return emps;
        }

        async Task<Employee> IDataAccess<Employee, int>.GetAsync(int id)
        {
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd = new SqlCommand($"Select * from Employee where EmpNo = {id}", Conn);
                var Reader = await Cmd.ExecuteReaderAsync();
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
                if (employee.EmpNo == 0)
                {
                    return null;
                }
                else
                {
                    return employee;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
                throw ex;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }

        async Task<int> IDataAccess<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            try
            {
                Conn.Open();
                Employee employee = new Employee();
                if (id == entity.EmpNo)
                {

                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Employee Set EmpName=@EmpName, Salary=@Salary, Designation=@Designation, DeptNo=@DeptNo, Email=@Email where EmpNo=@EmpNo";

                    SqlParameter pEmpNo = new SqlParameter();
                    pEmpNo.ParameterName = "@EmpNo";
                    pEmpNo.SqlDbType = SqlDbType.Int;
                    pEmpNo.Direction = ParameterDirection.Input;
                    pEmpNo.Value = id;

                    SqlParameter pEmpName = new SqlParameter();
                    pEmpName.ParameterName = "@EmpName";
                    pEmpName.SqlDbType = SqlDbType.VarChar;
                    pEmpName.Size = 200;
                    pEmpName.Direction = ParameterDirection.Input;
                    pEmpName.Value = entity.EmpName;

                    SqlParameter pSalary = new SqlParameter();
                    pSalary.ParameterName = "@Salary";
                    pSalary.SqlDbType = SqlDbType.Int;
                    pSalary.Direction = ParameterDirection.Input;
                    pSalary.Value = entity.Salary;

                    SqlParameter pDesignation = new SqlParameter();
                    pDesignation.ParameterName = "@Designation";
                    pDesignation.SqlDbType = SqlDbType.VarChar;
                    pDesignation.Size = 200;
                    pDesignation.Direction = ParameterDirection.Input;
                    pDesignation.Value = entity.Designation;

                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = entity.DeptNo;

                    SqlParameter pEmail = new SqlParameter();
                    pEmail.ParameterName = "@Email";
                    pEmail.SqlDbType = SqlDbType.VarChar;
                    pEmail.Size = 300;
                    pEmail.Direction = ParameterDirection.Input;
                    pEmail.Value = entity.Email;

                    Cmd.Parameters.Add(pEmpNo);
                    Cmd.Parameters.Add(pEmpName);
                    Cmd.Parameters.Add(pSalary);
                    Cmd.Parameters.Add(pDesignation);
                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pEmail);

                    int res = await Cmd.ExecuteNonQueryAsync();
                    Conn.Close();
                    return res;
                }
                else
                {
                    throw new Exception($"the {id} and {entity.EmpNo} does not match");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return 0;
            }
            finally
            {
                if (Conn.State == ConnectionState.Open)
                {
                    Conn.Close();
                }
            }
        }
    }
}
