using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{ 
    
        //2) Can we override the private virtual method of
        //   abstract class using public method from the deriuved class?
        //>> Can not have private method of abstract, can have public

    public abstract class Name
    {
        public virtual void Employee()
        {
            Console.WriteLine("Mayuri");
        }
    }

    public class Mayur : Name
    {
        public override void Employee()
        {
            Console.WriteLine("I am 21 Years Old");
        }
    }
}
