using Naukari_24March.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Naukari_24March.Services
{
    public class EmployerInfoService : IService<EmployerInfo, int>
    {
        private readonly NaukariContext ctx;

        public EmployerInfoService(NaukariContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<EmployerInfo> IService<EmployerInfo, int>.CreateAsync(EmployerInfo entity)
        {
            try
            {
                var result = await ctx.EmployerInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EmployerInfo> IService<EmployerInfo, int>.DeleteAsync(int id)
        {
            try
            {
                var info = await ctx.EmployerInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                ctx.EmployerInfos.Remove(info);
                await ctx.SaveChangesAsync();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<EmployerInfo>> IService<EmployerInfo, int>.GetAsync()
        {
            try
            {
                var result = await ctx.EmployerInfos.ToListAsync();
                await ctx.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EmployerInfo> IService<EmployerInfo, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.EmployerInfos.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EmployerInfo> IService<EmployerInfo, int>.UpdateAsync(int id, EmployerInfo entity)
        {
            try
            {
                var Update = await ctx.EmployerInfos.FindAsync(id);
                if (Update == null)
                {
                    return null;
                }
                ctx.Entry(Update).CurrentValues.SetValues(entity);
                await ctx.SaveChangesAsync();
                return Update;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
