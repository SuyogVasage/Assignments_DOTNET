using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22Feb_DB_EmpDep_by_disconnected
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        void GetData();
        void GetData(TPk id);
        void Create();
        void Update(TPk id);
        void Delete(TPk id);
    }
}
