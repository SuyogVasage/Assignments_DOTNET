using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Threading_26Feb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreData storeData = new StoreData();
            //storeData.GetEmpData();
            //storeData.GetEmpNo();

            Parallel.Invoke(() =>
            {
                storeData.GetEmpData();
                storeData.GetEmpNo();
            }
            );
            Console.ReadLine();

        }
    }
}
