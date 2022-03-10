
using SingleFilePulish_DLL;

Console.WriteLine("Hello, World!");

Calculator c = new Calculator();
c.write();

Console.WriteLine("Enter 1st number");
int x = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Enter 2nd number");
int y = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Addition = {c.Add(x, y)}");
Console.ReadLine();




