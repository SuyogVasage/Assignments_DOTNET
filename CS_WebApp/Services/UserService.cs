using CS_WebApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;

namespace CS_WebApp.Services
{
    public class UserService : IService<User, int>
    {
        private readonly IndustryContext ctx;
        /// <summary>
        /// Inject the IndustryContext
        /// </summary>
        /// <param name="ctx"></param>
        public UserService(IndustryContext ctx)
        {
            this.ctx = ctx;
        }

        async Task<User> IService<User, int>.CreateAsync(User entity)
        {
            try
            {
                var result = await ctx.Users.AddAsync(entity);
                await ctx.SaveChangesAsync();
                return result.Entity; // Return newly CReated ENtity
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<User> IService<User, int>.DeleteAsync(int id)
        {
            try
            {
                var userToFind = await ctx.Users.FindAsync(id);
                if (userToFind == null)
                {
                    return null;
                }
                ctx.Users.Remove(userToFind);
                await ctx.SaveChangesAsync();
                return userToFind;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<IEnumerable<User>> IService<User, int>.GetAsync()
        {
            try
            {
                var result = await ctx.Users.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<User> IService<User, int>.GetAsync(int id)
        {
            try
            {
                var result = await ctx.Users.FindAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        async Task<User> IService<User, int>.UpdateAsync(int id, User entity)
        {
            try
            {
                var userToUpdate = await ctx.Users.FindAsync(id);
                if (userToUpdate == null)
                {
                    return null;
                }
                userToUpdate.UserName = entity.UserName;
                userToUpdate.Password = entity.Password;
                await ctx.SaveChangesAsync();
                return userToUpdate;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
