using CS_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace CS_WebApp.Services
{
    public class EmpService : IService<Employee, int>
    {
        private readonly IndustryContext ctx;
        /// <summary>
        /// Inject the IndustryContext
        /// </summary>
        /// <param name="ctx"></param>
        public EmpService(IndustryContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Employee> IService<Employee, int>.CreateAsync(Employee entity)
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

        async Task<Employee> IService<Employee, int>.DeleteAsync(int id)
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

        async Task<IEnumerable<Employee>> IService<Employee, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Employees.ToListAsync();
                foreach (var item in result)
                {
                    item.Tax = item.Salary * 0.10;
                }
                await ctx.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IService<Employee, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.Employees.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Employee> IService<Employee, int>.UpdateAsync(int id, Employee entity)
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
