using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace _2_March_CRUD_Async
{
    internal class DeptDbAccess : IDataAccess<Department, int>
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public DeptDbAccess()
        {
            Conn = new SqlConnection(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Industry;Integrated Security=SSPI");
        }
        async Task IDataAccess<Department, int>.CreateAsync(Department entity)
        {
            try
            {
                Department emp = null;
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = $"Insert into Department Values({entity.DeptNo}, '{entity.DeptName}', '{entity.Location}', {entity.Capacity})";

                int res = await Cmd.ExecuteNonQueryAsync(); //executes the sql query and returns number of rows affected

                if (res == 0)
                {
                    emp = null;
                }
                else
                {
                    emp = new Department();
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

        async Task<int> IDataAccess<Department, int>.DeleteAsync(int id)
        {
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Delete From Department where DeptNo=@DeptNo";
                SqlParameter pDeptNo = new SqlParameter();
                pDeptNo.ParameterName = "@DeptNo";
                pDeptNo.SqlDbType = SqlDbType.Int;
                pDeptNo.Direction = ParameterDirection.Input;
                pDeptNo.Value = id;

                Cmd.Parameters.Add(pDeptNo);

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

        async Task<IEnumerable<Department>> IDataAccess<Department, int>.GetAsync()
        {
            List<Department> emps = new List<Department>();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd.CommandText = "Select * from Department";
                SqlDataReader EmpData = await Cmd.ExecuteReaderAsync();

                while (EmpData.Read())
                {
                    emps.Add(new Department()
                    {
                        DeptNo = Convert.ToInt32(EmpData["DeptNo"]),
                        DeptName = EmpData["DeptName"].ToString(),
                        Location = EmpData["Location"].ToString(),
                        Capacity = Convert.ToInt32(EmpData["Capacity"]),
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

        async Task<Department> IDataAccess<Department, int>.GetAsync(int id)
        {

            Department department = new Department();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd = new SqlCommand($"Select * from Department where DeptNo = {id}", Conn);
                SqlDataReader Reader = await Cmd.ExecuteReaderAsync();
                while (Reader.Read())
                {
                    department.DeptNo = Convert.ToInt32(Reader["DeptNo"]);
                    department.DeptName = Reader["DeptName"].ToString();
                    department.Location = Reader["Location"].ToString();
                    department.Capacity = Convert.ToInt32(Reader["Capacity"]);
                }
                Reader.Close();
                if (department.DeptNo == 0)
                {
                    return null;
                }
                else
                {
                    return department;
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

        async Task<int> IDataAccess<Department, int>.UpdateAsync(int id, Department entity)
        {
            try
            {
                Conn.Open();
                Department department = new Department();
                if (id == entity.DeptNo)
                {

                    Cmd = new SqlCommand();
                    Cmd.Connection = Conn;
                    Cmd.CommandText = "Update Department Set DeptName=@DeptName, Location=@Location, Capacity=@Capacity where DeptNo=@DeptNo";

                    SqlParameter pDeptNo = new SqlParameter();
                    pDeptNo.ParameterName = "@DeptNo";
                    pDeptNo.SqlDbType = SqlDbType.Int;
                    pDeptNo.Direction = ParameterDirection.Input;
                    pDeptNo.Value = id;

                    SqlParameter pDeptName = new SqlParameter();
                    pDeptName.ParameterName = "@DeptName";
                    pDeptName.SqlDbType = SqlDbType.VarChar;
                    pDeptName.Size = 200;
                    pDeptName.Direction = ParameterDirection.Input;
                    pDeptName.Value = entity.DeptName;

                    SqlParameter pLocation = new SqlParameter();
                    pLocation.ParameterName = "@Location";
                    pLocation.SqlDbType = SqlDbType.VarChar;
                    pLocation.Size = 200;
                    pLocation.Direction = ParameterDirection.Input;
                    pLocation.Value = entity.Location;

                    SqlParameter pCapacity = new SqlParameter();
                    pCapacity.ParameterName = "@Capacity";
                    pCapacity.SqlDbType = SqlDbType.Int;
                    pCapacity.Direction = ParameterDirection.Input;
                    pCapacity.Value = entity.Capacity;

                    Cmd.Parameters.Add(pDeptNo);
                    Cmd.Parameters.Add(pDeptName);
                    Cmd.Parameters.Add(pLocation);
                    Cmd.Parameters.Add(pCapacity);

                    int res = await Cmd.ExecuteNonQueryAsync();
                    return res;
                }
                else
                {
                    throw new Exception($"the {id} and {entity.DeptNo} does not match");
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

