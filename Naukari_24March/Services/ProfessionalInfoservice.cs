using Naukari_24March.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Naukari_24March.Services
{
    public class ProfessionalInfoservice : IService<ProfessionalInfo, int>
    {
        private readonly NaukariContext ctx;

        public ProfessionalInfoservice(NaukariContext ctx)  
        {
            this.ctx = ctx;
        }
        async Task<ProfessionalInfo> IService<ProfessionalInfo, int>.CreateAsync(ProfessionalInfo entity)
        {
            try
            {
                var result = await ctx.ProfessionalInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<ProfessionalInfo> IService<ProfessionalInfo, int>.DeleteAsync(int id)
        {
            try
            {
                var info = await ctx.ProfessionalInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                ctx.ProfessionalInfos.Remove(info);
                await ctx.SaveChangesAsync();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<ProfessionalInfo>> IService<ProfessionalInfo, int>.GetAsync()
        {
            try
            {
                var result = await ctx.ProfessionalInfos.ToListAsync();
                await ctx.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<ProfessionalInfo> IService<ProfessionalInfo, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.ProfessionalInfos.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<ProfessionalInfo> IService<ProfessionalInfo, int>.UpdateAsync(int id, ProfessionalInfo entity)
        {
            try
            {
                var info = await ctx.ProfessionalInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                info.CandidateId = entity.CandidateId;
                info.ExpInYears = entity.ExpInYears;
                info.Companies = entity.Companies;
                info.Projects = entity.Projects;
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
