using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CS_Owned_Types.Models
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

            modelBuilder.Entity<Person>()
                 .OwnsOne(p => p.CurrentAddress)
                 .OwnsOne(r => r.Region);

            //The Table Splitting, this will generate two tables Persons and Region
            modelBuilder.Entity<Person>()
                .OwnsOne(p => p.PermanentAddress)
                .ToTable("Region").
                OwnsOne(r => r.Region);
        }
    }
}
