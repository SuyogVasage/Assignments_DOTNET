using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Assignment_9_Feb
{
    internal class Departments : List<Department>
    {
        public Departments()
        {
            Add(new Department() { DeptNo = 1, DeptName = "SL", Location = "Mumbai", Capacity = 15 });
            Add(new Department() { DeptNo = 2, DeptName = "IT", Location = "Pune", Capacity = 30 });
            Add(new Department() { DeptNo = 3, DeptName = "Account", Location = "Banglore", Capacity = 10 });
            Add(new Department() { DeptNo = 4, DeptName = "Admin", Location = "Ratnagiri", Capacity = 10 });
            Add(new Department() { DeptNo = 5, DeptName = "SL", Location = "Chennai", Capacity = 35 });
            Add(new Department() { DeptNo = 6, DeptName = "IT", Location = "Mumbai", Capacity = 50 });
            Add(new Department() { DeptNo = 7, DeptName = "HR", Location = "Hyderabad", Capacity = 10 });
            Add(new Department() { DeptNo = 8, DeptName = "account", Location = "Pune", Capacity = 11 });
            Add(new Department() { DeptNo = 9, DeptName = "HR", Location = "Chennai", Capacity = 18 });
            Add(new Department() { DeptNo = 10, DeptName = "Admin", Location = "Delhi", Capacity = 8 });

        }

    }
}