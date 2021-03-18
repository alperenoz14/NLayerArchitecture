using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Data.Configurations;
using NLayerArchitecture.Data.Seeds;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecture.Data
{
    public class AppDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-NNE3V2L\MSSQLDATABASE;Database=NLayerDB;Trusted_Connection=True",
                options => options.MigrationsAssembly("NLayerArchitecture.Data")
                );
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder.ApplyConfiguration(new ProductSeed(new int[] { 1, 2 }));
            modelBuilder.ApplyConfiguration(new CategorySeed(new int[] { 1, 2 }));

            //That's how you do models configuration without using seperate folder,

            //modelBuilder.Entity<Person>().HasKey(x => x.Id);
            //modelBuilder.Entity<Person>().Property(x => x.Id).UseIdentityColumn();
        }
    }
}
