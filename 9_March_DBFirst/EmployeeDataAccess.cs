using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _9_March_DBFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace _9_March_DBFirst
{
    public class EmployeDataAccess : IDataAccess<Employee, int>
    {
        IndustryContext ctx;
        public EmployeDataAccess()
        {
            ctx = new IndustryContext();
        }

        async Task<Employee> IDataAccess<Employee, int>.CreateAsync(Employee entity)
        {
            try
            {
                var result = await ctx.Employees.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IDataAccess<Employee, int>.DeleteAsync(int id)
        {
            try
            {
                var empToFind = await ctx.Employees.FindAsync(id);
                if (empToFind == null)
                {
                    return null;
                }
                ctx.Employees.Remove(empToFind);
                await ctx.SaveChangesAsync();
                return empToFind;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<Employee>> IDataAccess<Employee, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Employees.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IDataAccess<Employee, int>.UpdateAsync(int id, Employee entity)
        {
            try
            {
                var empToUpdate = await ctx.Employees.FindAsync(id);
                if (empToUpdate == null)
                {
                    return null;
                }
                empToUpdate.EmpName = entity.EmpName;
                empToUpdate.Salary = entity.Salary;
                empToUpdate.Designation = entity.Designation;
                empToUpdate.DeptNo = entity.DeptNo;
                empToUpdate.Email = entity.Email;
                await ctx.SaveChangesAsync();
                return empToUpdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
