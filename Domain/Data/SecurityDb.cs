using Microsoft.EntityFrameworkCore;

namespace Domain.Data
{ 
    public class SecurityDb : DbContext
    {
        public DbSet<DataItem> DataItems { get; set; }

        public SecurityDb(DbContextOptions<SecurityDb> options)
       : base(options)
        {
        }

        // DbContext OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "DefaultConnection",
                    options => options.MigrationsAssembly("Security Webapp")
                );
            }
        }

        //DbContext OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
