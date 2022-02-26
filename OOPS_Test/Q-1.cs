using System;

namespace OOPS_Test
{
    internal class Program
    {
        //1) Can overloading is possible by having same method name with same number
        //   and order of parameters but different in return type?
        //>>Not possible
        static int Add(int x, int y)
        {
            return x + y;
        }

        static  double Add1(int x, int y)
        {
            return (double)x + y;
        }
        
    }
}
