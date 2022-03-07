using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _7_March_CRUD_EFcore.Models;
using Microsoft.EntityFrameworkCore;

namespace _7_March_CRUD_EFcore
{
    internal class DepartmentDataAccess : IDataAccess<Department, int>
    {

        IndustryContext ctx;

        public DepartmentDataAccess()
        {
            ctx = new IndustryContext();
        }

        async Task<Department> IDataAccess<Department, int>.CreateAsync(Department entity)
        {
            try
            {
                var result = await ctx.Departments.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Department> IDataAccess<Department, int>.DeleteAsync(int id)
        {
            try
            {
                var deptToFind = await ctx.Departments.FindAsync(id);
                if (deptToFind == null)
                {
                    return null;
                }
                ctx.Departments.Remove(deptToFind);
                await ctx.SaveChangesAsync();
                return deptToFind;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<Department>> IDataAccess<Department, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Departments.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Department> IDataAccess<Department, int>.UpdateAsync(int id, Department entity)
        {
            try
            {
                var deptToUpdate = await ctx.Departments.FindAsync(id);
                if (deptToUpdate == null)
                {
                    return null;
                }
                deptToUpdate.DeptName = entity.DeptName;
                deptToUpdate.Capacity = entity.Capacity;
                deptToUpdate.Location = entity.Location;
                await ctx.SaveChangesAsync();
                return deptToUpdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
