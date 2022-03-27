using CS_WebApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

namespace CS_WebApp.Services
{
    public class ExceptionLogService : IService<ExceptionLog, int>
    {

        private readonly IndustryContext ctx;
        public ExceptionLogService(IndustryContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<ExceptionLog> IService<ExceptionLog, int>.CreateAsync(ExceptionLog entity)
        {
            try
            {
                var result = await ctx.ExceptionLogs.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        Task<ExceptionLog> IService<ExceptionLog, int>.DeleteAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        async Task<IEnumerable<ExceptionLog>> IService<ExceptionLog, int>.GetAsync()
        {
            try
            {
                var result = await ctx.ExceptionLogs.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        Task<ExceptionLog> IService<ExceptionLog, int>.GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<ExceptionLog> IService<ExceptionLog, int>.UpdateAsync(int id, ExceptionLog entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
