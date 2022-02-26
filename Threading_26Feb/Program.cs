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
            Thread t1 = new Thread(() => storeData.WriteDateToDB());
            Thread t2 = new Thread(() => storeData.WriteDataToFile());
            t1.Start();
            t2.Start();
            //storeData.WriteDateToDB();
            //storeData.WriteDataToFile();
            //storeData.GetDataFromFile();
            Console.ReadLine();

        }
    }
}
