using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_Dispose
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Myclass myclass = new Myclass();
            //myclass.Display();
            //myclass.Dispose();

            //using block
            using (Myclass m1 = new Myclass())
            {
                Console.WriteLine("Inside using block");
                m1.Dispose();
                
            }
            Console.ReadLine();
        }
    }

    public class Myclass : IDisposable
    {
        public Myclass()
        {
            Console.WriteLine("Constructor called");
        }

        public void Display()
        {
            Console.WriteLine("Call Display");
        }

        public void Dispose()
        {
            Console.WriteLine("Calling Dispose");
            //kill th object
            GC.SuppressFinalize(this);
        }

        ~Myclass()
        {
            Console.WriteLine("Called Destructor");
            Console.ReadLine();
        }
    }
}
