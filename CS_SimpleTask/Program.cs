using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace CS_SimpleTask
{
    internal class Program
    {
        static void Main(string[] args)

        {
            Console.WriteLine("Tasks ");
            // 1. Create a TAsk and Assign a Workload to it
            Task t1 = new Task(() => { writeFile(); });
            // Start the TAsk
            t1.Start();
            Console.WriteLine("BAck to MAin THread");
            Console.ReadLine();
        }

        static void writeFile()
        {
            try
            {
                string path = @"C:\Users\Coditas\Documents\TaskDemoFile";
                FileStream Fs = new FileStream(path, FileMode.CreateNew, FileAccess.Write);
                StreamWriter sw = new StreamWriter(Fs);
                sw.WriteLine($"Data is written over a Task On Thraed {Thread.CurrentThread.ManagedThreadId}");

                Console.WriteLine("Data is Writen into the File");
                sw.Close();
                Fs.Close();
                sw.Dispose();
                Fs.Dispose();
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error Ocured While Writing into File {ex.Message}");
            }
        }
    }
}

