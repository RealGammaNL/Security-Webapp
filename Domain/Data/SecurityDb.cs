using Microsoft.EntityFrameworkCore;

//This program is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or(at your option) any later version.
//This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the GNU General Public License for more details.
//You should have received a copy of the GNU General Public License along with this program.If not, see<https://www.gnu.org/licenses/>. 

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
