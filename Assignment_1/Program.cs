using System;

namespace Assignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Accept first number
            Console.WriteLine("Enter first number");
            int num1 = Convert.ToInt32(Console.ReadLine());

            //Accept second number
            Console.WriteLine("Enter second number");
            int num2 = Convert.ToInt32(Console.ReadLine());

            //Accept a string of user choice
            Console.WriteLine("Enter string \nAddition - Add\nSubtraction - Sub\nMultiplication - Mult\nDivision - Div\nSquare of first number - Square1\nSquare of second number - Square2");
            string c = Console.ReadLine();
            
            //Print Process(), which is kind of calculator 
            Console.WriteLine($"Calculator : {c} = {Process(num1, num2, c)}");
        }
           static int Add(int a, int b)
            {
                //Check whether the input integers are either negative or zero 
                if(a <= 0 || b <= 0) 
                {
                    return 0;
                }
                else
                {
                    return a + b;
                }  
            }
            static int Sub(int a, int b)
            {
            //Check whether the input integers are either negative or zero 
            if (a <= 0 || b <= 0)
                {
                    return 0;
                }
                else
                {
                    return a - b;
                }
            }
            static int Multiplication(int a, int b)
            {
            //Check whether the input integers are either negative or zero 
            if (a <= 0 || b <= 0)
                {
                    return 0;
                }
                else
                {
                    return a * b;
                }
            }
            static int Division(int a, int b)
            {
            //Check whether the input integers are either negative or zero 
            if (a <= 0 || b <= 0)
                {
                    return 0;
                }
                else
                {
                    return a / b;
                };
            }
            static int Square(int a)
            {
            //Check whether the input integer are either negative or zero 
            if (a <= 0)
                {
                    return 0;
                }
                else
                {
                    return a * a;
                }
            }
        static int Process(int a, int b, string c)
        {
                switch (c.ToLower())
                {
                    //According to the given input string, calculator operation will takes place using previous methods
                    case "add":
                        return Add(a, b);
                        break;
                    case "sub":
                        return Sub(a, b);
                        break;
                    case "mult":
                        return Multiplication(a, b);
                        break;
                    case "div":
                        return Division(a, b);
                        break;
                    case "square1":
                        return Square(a);
                        break;
                    case "square2":
                        return Square(b);
                        break;
                    default:
                        return 0;
                }
                
            }
        }
    }

