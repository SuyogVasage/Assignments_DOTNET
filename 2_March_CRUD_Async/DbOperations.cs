using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2_March_CRUD_Async
{
    internal class DbOperartion : IDisposable
    {
        SqlConnection Conn;
        SqlCommand Cmd;
        public DbOperartion()
        {
            Conn = new SqlConnection(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Industry;Integrated Security=SSPI");
        }
        public async Task<Employee> GetEmpDataAsync(int id)
        {
            Employee employee = new Employee();
            try
            {
                Conn.Open();
                Cmd = new SqlCommand();
                Cmd.Connection = Conn;
                Cmd = new SqlCommand($"Select * from Employee where EmpNo = {id}", Conn);
                SqlDataReader Reader = await Cmd.ExecuteReaderAsync();
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
            return employee;
        }
        public async Task<IEnumerable<Employee>> GetEmpDataAsync() 
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
        public async void CreateEmpDataAsync(Employee entity)
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
        public async void DeleteEmpDataAsync(int id)
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
        public async void UpdateEmpDataAsync(Employee entity, int id)
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
                    if (res == 0)
                    {
                        employee = null;
                    }
                    else
                    {
                        employee = entity;
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.EmpNo} does not match");
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        public async Task<Department> GetDeptDataAsync(int id)
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
            return department;
        }
        public async Task<IEnumerable<Department>> GetDeptDataAsync()
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
        public async void CreateDeptDataAsync(Department entity)
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
        public async void UpdateDeptDataAsync(Department entity, int id)
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
                    if (res == 0)
                    {
                        department = null;
                    }
                    else
                    {
                        department = entity;
                    }
                }
                else
                {
                    throw new Exception($"the {id} and {entity.DeptNo} does not match");
                }
                Conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async void DeleteDeptDataAsync(int id) 
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

        public void Dispose()
        {
            Conn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
