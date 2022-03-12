using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _11_March_Practical.Models;
using Microsoft.EntityFrameworkCore;

namespace _11_March_Practical
{
    public class DataAccess
    {
        ClinicContext ctx;

        public DataAccess()
        {
            ctx = new ClinicContext();
        }

        public async Task<IEnumerable<MedicalInfo>> GetAsync()
        {
            try
            {
                var result = await ctx.MedicalInfos.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<MedicalInfo> GetAsync(int id)

        {
            try
            {
                var result = await ctx.MedicalInfos.FindAsync(id);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<DailyReport> GetReportAsync(int id) 
        {
            try
            {
                var result = await ctx.DailyReports.FindAsync(id);
                if (result == null)
                {
                    return null;
                }
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Patient> CreatePatientAsync(Patient entity)
        {
            try
            {
                var result = await ctx.Patients.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<DailyReport> CreateReportAsync(DailyReport entity)
        {
            try
            {
                var result = await ctx.DailyReports.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<MedicalInfo> CreateMDIndoAsync(MedicalInfo entity)
        {
            try
            {
                var result = await ctx.MedicalInfos.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        } 

        public void DailyReport()
        {
            try
            {
                Console.WriteLine("Enter Date To get Daily collection (Should be in the fromat YYYY-MM-DD)");
                DateTime dateTime = Convert.ToDateTime(Console.ReadLine());
                var totalCollection = ctx.DailyReports.Where(x => x.Date == dateTime).Sum(x => x.Fees);
                Console.WriteLine($"Total collection for {dateTime} is ={totalCollection} Rs.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
