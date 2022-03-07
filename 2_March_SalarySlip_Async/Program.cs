using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2_March_SalarySlip_Async.Files;

namespace _2_March_SalarySlip_Async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Operation op = new Operation();
            Employees employees = new Employees();
            Task.Factory.StartNew(() => op.WriteFiles())
                .ContinueWith(delegate { op.moveFile(); });
            Console.ReadLine();
        }
    }
}
