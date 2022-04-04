using WebAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace WebAPI.Services
{
    public class ProductService : IService<Product, int>
    {
        private readonly ApiDbContext ctx;
        public ProductService(ApiDbContext ctx)
        {
            this.ctx = ctx;
        }
        async Task<Product> IService<Product, int>.CreateAsync(Product entity)
        {
            try
            {
                var result = await ctx.Products.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
#pragma warning disable CS8603 // Possible null reference return.
                return null;
#pragma warning restore CS8603 // Possible null reference return.
            }
        }

        async Task<Product> IService<Product, int>.DeleteAsync(int id)
        {
            try
            {
                var userToFind = await ctx.Products.FindAsync(id);
                if (userToFind == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
                ctx.Products.Remove(userToFind);
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

        async Task<IEnumerable<Product>> IService<Product, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Products.ToListAsync();
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

        async Task<Product> IService<Product, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.Products.FindAsync(id);
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

        async Task<Product> IService<Product, int>.UpdateAsync(int id, Product entity)
        {
            try
            {
                var Update = await ctx.Products.FindAsync(id);
                if (Update == null)
                {
#pragma warning disable CS8603 // Possible null reference return.
                    return null;
#pragma warning restore CS8603 // Possible null reference return.
                }
                ctx.Entry(Update).CurrentValues.SetValues(entity);
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
