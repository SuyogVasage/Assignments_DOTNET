using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SelfStudy_9Feb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //The FirstOrDefault() method does the same thing as First() method. The only difference is
                //that it returns default value of the data type of a
                //collection if a collection is empty or doesn't find any element that satisfies the condition.
                Console.WriteLine("Use of First()");
                List<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
                List<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                List<string> emptyList = new List<string>();
                Console.WriteLine($"1st Element in intList: {intList.First()}");
                Console.WriteLine($"1st even Element in intList: {intList.First(i => i % 2 == 0)}");
                Console.WriteLine("1st Element in strList: {0}", strList.First());
               // Console.WriteLine("1st Element in emptyList: {0}", emptyList.First()); //give error

                Console.WriteLine("Useof FirstOrDefault()");
                Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
                Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());
                Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());  //give default value



                //The LstOrDefault() method does the same thing as Last() method. The only difference is
                //that it returns default value of the data type of a
                //collection if a collection is empty or doesn't find any element that satisfies the condition.
                Console.WriteLine("Use of Last()");
                Console.WriteLine($"1st Element in intList: {intList.Last()}");
                Console.WriteLine($"1st even Element in intList: {intList.Last(i => i % 2 == 0)}");
                Console.WriteLine("1st Element in strList: {0}", strList.Last());
                //Console.WriteLine("1st Element in emptyList: {0}", emptyList.Last());  //give error

                Console.WriteLine("Useof FirstOrDefault()");
                Console.WriteLine("1st Element in intList: {0}", intList.LastOrDefault());
                Console.WriteLine("1st Element in strList: {0}", strList.LastOrDefault());
                Console.WriteLine("1st Element in emptyList: {0}", emptyList.LastOrDefault()); //give default value


                //The Count operator returns the number of elements in the collection or number
                //of elements that have satisfied the given condition.
                Console.WriteLine("Use of Count()");
                Console.WriteLine($"Total Element in intList :{intList.Count()}");


                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
        }
    }
}
