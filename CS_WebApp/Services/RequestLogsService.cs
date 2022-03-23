using Microsoft.EntityFrameworkCore;
using System;
using CS_WebApp.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CS_WebApp.Services
{
    public class RequestLogsService : IService<RequestLog, int>
    {
        private readonly IndustryContext ctx;
        /// <summary>
        /// Inject the IndustryContext
        /// </summary>
        /// <param name="ctx"></param>
        public RequestLogsService(IndustryContext ctx)
        {
            this.ctx = ctx;
        }

        Task<RequestLog> IService<RequestLog, int>.CreateAsync(RequestLog entity)
        {
            throw new NotImplementedException();
        }

        Task<RequestLog> IService<RequestLog, int>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        async Task<IEnumerable<RequestLog>> IService<RequestLog, int>.GetAsync()
        {
            try
            {
                var result = await ctx.RequestLogs.ToListAsync();
                return result; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        Task<RequestLog> IService<RequestLog, int>.GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<RequestLog> IService<RequestLog, int>.UpdateAsync(int id, RequestLog entity)
        {
            throw new NotImplementedException();
        }
    }
}
