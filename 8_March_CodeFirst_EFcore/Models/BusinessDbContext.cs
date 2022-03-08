using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace _8_March_CodeFirst_EFcore.Models
{
    public class BusinessDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        public BusinessDbContext()
        {

        }

        /// <summary>
        /// Configure the Connection String
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=Business;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }
        /// <summary>
        /// Using the FLuent APIs
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                        .HasOne(c => c.Course) // One-To-One
                        .WithMany(p => p.Students) // One-To-Many
                        .HasForeignKey(p => p.CourseID); // FOreign Key
            base.OnModelCreating(modelBuilder);
        }
    }
}
