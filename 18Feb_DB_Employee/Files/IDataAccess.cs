using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Feb_DB_Employee.Files
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetData();
        TEntity GetData(TPk id);
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        TEntity Delete(TPk id);
    }

    internal interface IDataAccess2<TEntity, in TKey> where TEntity : class 
    {
        void GetAllEmployeesByDeptName(TKey id);
        void GetAllEmployeesWithMaxSalByDeptName(TKey id);
        void GetSumSalaryByDeptName(TKey id);
        void GetAllEmployeesByLocation(TKey id);

    }
}
