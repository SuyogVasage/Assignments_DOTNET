using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EFCore_Features_Link_2.Models
{
    public class PersonalInformationDB : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=PersonInfo;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>()
            //    .Property("Email").HasField("_Email");
            //modelBuilder.Entity<Person>()
            //    .Property("ContactNo").HasField("_ContactNo");
            modelBuilder.Entity<Person>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
