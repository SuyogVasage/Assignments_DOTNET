using CS_WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CS_WebApp.Services
{
    public class DeptService : IService<Department, int>
    {
        private readonly IndustryContext ctx;
        /// <summary>
        /// Inject the IndustryContext
        /// </summary>
        /// <param name="ctx"></param>
        public DeptService(IndustryContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Department> IService<Department, int>.CreateAsync(Department entity)
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

        async Task<Department> IService<Department, int>.DeleteAsync(int id)
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

        async Task<IEnumerable<Department>> IService<Department, int>.GetAsync()
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

        async Task<Department> IService<Department, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.Departments.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<Department> IService<Department, int>.UpdateAsync(int id, Department entity)
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

