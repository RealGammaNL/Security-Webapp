using System;

public class SecurityDb
{
	public SecurityDb()
	{
		// DbContext constructor      
        public SecurityDb(DbContextOptions<SecurityDb> contextOptions) 
            : base(contextOptions)
            {
            
            }

        // DbContext OnConfiguring method
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
            }

        //DbContext OnModelCreating method
        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
            }
	}
}
