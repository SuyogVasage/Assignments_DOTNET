// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");


List<object> objectist = new List<object>()
{
    new List<string> { "Suyog", "Mayur" , "Yash", "Shreya", "Jahanvi", "Harsh", "Onkar", "Sasi", "Deepak", "Raman"},
    new List<char> { 'a', 'b', 'c', 'd', 'e', 'f', 'g','h', 'i','j'},
    new List<int> {90,80,70,60 },
    new List<Employee>
    { (new Employee() { EmpNo = 101, EmpName = "Suyog  ", DeptName = "IT     ", Designation = "Director", Salary = 70000 }),
      (new Employee() { EmpNo = 102, EmpName = "Ajay   ", DeptName = "HR     ", Designation = "Director", Salary = 65000 }),
      (new Employee() { EmpNo = 103, EmpName = "Mayur  ", DeptName = "Admin  ", Designation = "Director", Salary = 73000 }),
      (new Employee() { EmpNo = 104, EmpName = "Durvesh", DeptName = "SL     ", Designation = "Director", Salary = 60000 }),
      (new Employee() { EmpNo = 105, EmpName = "Pranav ", DeptName = "Account", Designation = "Director", Salary = 70000 }),
      (new Employee() { EmpNo = 106, EmpName = "Shikhar", DeptName = "IT     ", Designation = "Manager ", Salary = 50000 }),
      (new Employee() { EmpNo = 107, EmpName = "Uday   ", DeptName = "HR     ", Designation = "Manager ", Salary = 45000 }),
      (new Employee() { EmpNo = 108, EmpName = "Deepak ", DeptName = "Admin  ", Designation = "Manager ", Salary = 48000 }),
      (new Employee() { EmpNo = 109, EmpName = "Raman  ", DeptName = "SL     ", Designation = "Manager ", Salary = 40000 }),
      (new Employee() { EmpNo = 110, EmpName = "Sasi   ", DeptName = "Account", Designation = "Manager ", Salary = 60000 })
    },
    new List<DateTime>
    {
        new DateTime(2015, 12, 31),
        new DateTime(2020, 12, 31),
        new DateTime(2022, 12, 31),
        new DateTime(2019, 12, 31),
        new DateTime(2018, 12, 31),
        new DateTime(2017, 12, 31),
        new DateTime(2016, 12, 31),
        new DateTime(2013, 12, 31),
        new DateTime(2014, 12, 31),
        new DateTime(2021, 12, 31),
    },
        
        10.5,20.3,30.5,40.7, 60.8, 10.56, 90.23, 12.4, 23.4, 45.6,
        1, 2, 3, 4, 5, 6, 7, 8, 9, 10,
       
};


ProcessCollection(objectist, out List<DateTime> DateTimeList, out List<int> IntList, out List<string> StringList, out List<char> CharList, out List<double> DoubleList, out List<Employee> EmpList);

foreach (var date in DateTimeList)
{
    Console.WriteLine(date);
}
foreach (var i in IntList)
{
    Console.WriteLine(i);
}
foreach (var str in StringList)
{
    Console.WriteLine(str);
}
foreach (var ch in CharList)
{
    Console.WriteLine(ch);
}
foreach (var doub in DoubleList)
{
    Console.WriteLine(doub);
}
foreach (var emp in EmpList)
{
    Console.WriteLine($"{emp.EmpNo} {emp.EmpName} {emp.Designation} {emp.DeptName} {emp.Salary}");
}




static void ProcessCollection(List<object> values, out List<DateTime> DateTimeList, out List<int> IntList, out List<string> StringList, out List<char> CharList, out List<double> DoubleList, out List<Employee> EmpList) 
{
    DateTimeList = new List<DateTime>();
    IntList = new List<int>();
    StringList = new List<string>();
    CharList = new List<char>();
    DoubleList = new List<double>();
    EmpList = new List<Employee>();
    Console.WriteLine("Processing a collection");
    foreach (object val in values)
    {
        switch (val)
        {
            case IEnumerable<int> intList:
                foreach (int i in intList)
                {
                    IntList.Add(i);
                }
                break;
            case IEnumerable<string> strList:
                foreach (var item in strList)
                {
                    StringList.Add(item);
                }
                break;
            case string s:
                StringList.Add(s);
                break;
            case IEnumerable<Employee> employees:
                foreach (Employee employee in employees)
                {
                    EmpList.Add(employee);
                }
                Console.WriteLine("employee list");
                break;
            case char c:
                CharList.Add(c);
                break;
            case double d:
                DoubleList.Add(d);
                break;
            case int i:
                IntList.Add(i);
                break;
            case IEnumerable<DateTime> data:
                foreach (DateTime i in data)
                {
                    DateTimeList.Add(i);
                }
                break;
            default:
                Console.WriteLine("Finally.....");
                break;
        }
    }
}



internal class Employee
{
    public int EmpNo { get; set; }
    public string? EmpName { get; set; }
    public string? DeptName { get; set; }
    public string? Designation { get; set; }
    public int Salary { get; set; }
}
