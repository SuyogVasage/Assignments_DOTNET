using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

//dotnet ef migrations add firstMigration -c CS_ScalarFunctions.Models.PersonalInformationDB

//dotnet ef database update -c CS_ScalarFunctions.Models.PersonalInformationDB
namespace CS_ScalarFunctions.Models
{
    public class PersonalInformationDB : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=SVASAGE-LAP-047\SQLEXPRESS;Initial Catalog=PersonInfo;Integrated Security=SSPI");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasKey("EmpId");
        }
    }
}
