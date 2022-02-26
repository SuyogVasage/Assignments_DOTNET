using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //5) Can we type cast the derived class instance using the base class?
    //>> No
    public class Employee11
    {
        public void Subtraction(int a, int b)
        {
            Console.WriteLine(a - b);
        }
    }
    

    public class Manager : Employee11
    {
        public void Addition(int a, int b)
        {
            Console.WriteLine(a + b);
        }
    }

}
