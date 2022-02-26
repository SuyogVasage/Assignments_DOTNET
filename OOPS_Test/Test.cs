using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    public abstract class Test1
    {

        /*static void Main1(string[] args)
        {
            //Test2 test2 = new Test2();
            //Console.WriteLine(((Test1)test2).Add(2, 3, 4,5 ));
            //Console.WriteLine(test2.Add(1, 2));
           // Console.WriteLine(test2.Add(1, 2, 3));

            // Console.WriteLine(Add(2, 3));
            // Console.WriteLine(Add(200, 499));
        }*/
        public abstract int Add(int x, int y, int z, int a);

        //public abstract int Mult(int x, int y, int z, int a);

        /* {
             return x + y + z + a;
         }*/

        //internal string EmpName { get; set;}



    }
   public class Test2 : Test1
    {
        public override int Add(int x, int y, int z, int a)
        {
            return x + y + z + a;
        }

        //public new string EmpName { get; set; }

    }
}
