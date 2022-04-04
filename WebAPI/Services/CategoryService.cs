using WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI.Services
{
    public class CategoryService : IService<Category, int>
    {
        private readonly ApiDbContext ctx;
        /// <summary>
        /// Inject the IndustryContext
        /// </summary>
        /// <param name="ctx"></param>
        public CategoryService(ApiDbContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<Category> IService<Category, int>.CreateAsync(Category entity)
        {
            //try
            //{
                var result = await ctx.Categories.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            //}
//            catch (Exception ex)
//            {
//                Console.WriteLine(ex.Message);
//#pragma warning disable CS8603 // Possible null reference return.
//                return null;
//#pragma warning restore CS8603 // Possible null reference return.
//            }
        }

        async Task<Category> IService<Category, int>.DeleteAsync(int id)
        {
            try
            {
                var userToFind = await ctx.Categories.FindAsync(id);
                if (userToFind == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
                ctx.Categories.Remove(userToFind);
                await ctx.SaveChangesAsync();
                return userToFind;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        async Task<IEnumerable<Category>> IService<Category, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Categories.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        async Task<Category> IService<Category, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.Categories.FindAsync(id);
#pragma warning disable CS8603 // Possible null reference return.
                return result;
#pragma warning restore CS8603 // Possible null reference return.
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        async Task<Category> IService<Category, int>.UpdateAsync(int id, Category entity)
        {
            try
            {
                var Update = await ctx.Categories.FindAsync(id);
                if (Update == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
                //Update.CategoryID = entity.CategoryID;
                //Update.CategoryName = entity.CategoryName;
                //Update.BasePrice = entity.BasePrice;\
                ctx.Entry(Update).CurrentValues.SetValues(entity);
                await ctx.SaveChangesAsync();
                return Update;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }
    }
}
