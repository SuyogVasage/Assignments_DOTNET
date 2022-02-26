using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //4) Can we have method overloading across base and derived classe?
   //>> Yes
    public class Employee1
    {
        static int Add(int x, int y)
        {
            return x + y;
        }

    }

    public class Employee3 : Employee1
    {
        static int Add(int x, int y, int z)
        {
            return x + y + z;
        }

    }

}
