using Naukari_24March.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Naukari_24March.Services
{
    public class PersonalInfoService : IService<PersonalInfo, int>
    {
        private readonly NaukariContext ctx;

        public PersonalInfoService(NaukariContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<PersonalInfo> IService<PersonalInfo, int>.CreateAsync(PersonalInfo entity)
        {
            try
            {
                var result = await ctx.PersonalInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; 
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<PersonalInfo> IService<PersonalInfo, int>.DeleteAsync(int id)
        {
            try
            {
                var info = await ctx.PersonalInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                ctx.PersonalInfos.Remove(info);
                await ctx.SaveChangesAsync();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<PersonalInfo>> IService<PersonalInfo, int>.GetAsync()
        {
            try
            {
                var result = await ctx.PersonalInfos.ToListAsync();
                await ctx.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<PersonalInfo> IService<PersonalInfo, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.PersonalInfos.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<PersonalInfo> IService<PersonalInfo, int>.UpdateAsync(int id, PersonalInfo entity)
        {
            try
            {
                var info = await ctx.PersonalInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                ctx.Entry(info).CurrentValues.SetValues(entity);
                await ctx.SaveChangesAsync();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
