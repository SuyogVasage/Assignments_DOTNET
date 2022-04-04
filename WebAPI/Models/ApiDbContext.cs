namespace WebAPI.Models
{
    public class ApiDbContext : DbContext
    {
        /// <summary>
        ///  Define prop ob Dbset for mapping CLR object to DB
        /// </summary>
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<RequestLog> RequestLogs { get; set; }
        public DbSet<ExceptionLog> ExceptionLogs { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .HasOne(c => c.Category) // One-To-One
                        .WithMany(p => p.Products) // One-To-Many
                        .HasForeignKey(p => p.CategoryRowID); // FOreign Key
            base.OnModelCreating(modelBuilder);
        }

    }
}

//dotnet ef migrations add newMigration -c WebAPI.Models.ApiDbContext
