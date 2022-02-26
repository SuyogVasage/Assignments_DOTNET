using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS_Test
{
    //3) Can we have private and protected abstract and virtual methods in abstract base class?
    //>> Virtual or abstract method can not be private, Can have protected virtual and abstract
    public abstract class Employee
    {
        private void method1()
        {
            Console.Write("Method1");     
        }
        protected abstract void method2();
        protected virtual void methode3()
        {
            Console.WriteLine("Method3");
        }

    }

    public class Employee2 : Employee
    {
        protected override void method2()
        {
            Console.Write("Method2");
        }

    }

}
