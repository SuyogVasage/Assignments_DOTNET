using System;

namespace Extension_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            MyMath myMath = new MyMath();
            
            string str = "My name is Suyog. I live in Ratnagiri.";
            int num1 = 5;
            int num2 = 64;
            int num3 = 4;
            Console.WriteLine($"Addition of  = {myMath.Add(num1, num2)}");
            Console.WriteLine($"{num1} raise to {num3} = {myMath.GetPow(num1, num3)}");
            Console.WriteLine($"factorial of {num3} = {myMath.Factorialofn(num3)}");
            Console.WriteLine($"Cube root of {num2} = {myMath.CubeRootn(num2)}");
            Console.WriteLine($"Number of statements in the {str} are {str.CountStatements()}");

        }

    }

    public sealed class MyMath
    {
        public int Add(int num1, int num2)

        {
            return num1 + num2;
        }
    }

    public static class Extension
    {
        public static double GetPow(this MyMath math,int x, int y)
        {
            return Math.Pow(x, y);
            
        }

        public static double Factorialofn(this MyMath math, int x)
        {
            double fact = 1;
            for (int i = 1; i <= x; i++)
            {
                fact = fact * i;
            }
            return fact;
        }

        public static double CubeRootn(this MyMath math, int x)
        {
            
            double cubeRoot = Math.Cbrt(x);
            return cubeRoot;
        }

        public static int CountStatements(this string str)
        {
            int statement = 0;
            foreach (char c in str)
            {
                if (c == '.')
                {
                    statement++;
                }
            }
            return statement;
        }

    }

   
}
