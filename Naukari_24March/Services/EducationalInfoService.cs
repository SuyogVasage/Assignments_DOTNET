using Naukari_24March.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Naukari_24March.Services
{
    public class EducationalInfoService : IService<EducationInfo, int>
    {
        private readonly NaukariContext ctx;

        public EducationalInfoService(NaukariContext ctx)  
        {
            this.ctx = ctx;
        }

        async Task<EducationInfo> IService<EducationInfo, int>.CreateAsync(EducationInfo entity)
        {
            try
            {
                var result = await ctx.EducationInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EducationInfo> IService<EducationInfo, int>.DeleteAsync(int id)
        {
            try
            {
                var info = await ctx.EducationInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                ctx.EducationInfos.Remove(info);
                await ctx.SaveChangesAsync();
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<EducationInfo>> IService<EducationInfo, int>.GetAsync()
        {
            try
            {
                var result = await ctx.EducationInfos.ToListAsync();
                await ctx.SaveChangesAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EducationInfo> IService<EducationInfo, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.EducationInfos.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<EducationInfo> IService<EducationInfo, int>.UpdateAsync(int id, EducationInfo entity)
        {
            try
            {
                var info = await ctx.EducationInfos.FindAsync(id);
                if (info == null)
                {
                    return null;
                }
                info.CandidateId = entity.CandidateId;
                info.SscpassYear = entity.SscpassYear;
                info.Sscpercentage = entity.Sscpercentage;
                info.HscpassYear = entity.HscpassYear;
                info.Hscpercentage = entity.Hscpercentage;
                info.DiplomaPassYear = entity.DiplomaPassYear;
                info.DiplomaPercentage = entity.DiplomaPercentage;
                info.DegreePassYear = entity.DegreePassYear;
                info.DegreePercentage = entity.DegreePercentage;
                info.DegreeName = entity.DegreeName;
                info.MastersPassYear = entity.MastersPassYear;
                info.MastersPercentage = entity.MastersPercentage;
                info.MastersName = entity.MastersName;
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
