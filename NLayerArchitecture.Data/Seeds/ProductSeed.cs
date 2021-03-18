using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecture.Data.Seeds
{
    public class ProductSeed : IEntityTypeConfiguration<Product>
    {
        private readonly int[] _CategoryIds;
        public ProductSeed(int[] ids)
        {
            _CategoryIds = ids;
        }

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product() { ID = 1, Name = "Asus", Price = 400, Stock = 200, CategoryId = _CategoryIds[0] },             //eger ID kolonunu auto increase belirlemişsen bile, 
                new Product() { ID = 2, Name = "Lenovo", Price = 500, Stock = 300, CategoryId = _CategoryIds[0] },             //böyle seed data veriyorsan kesinlikle başlangıc idsi vermelisin.
                new Product() { ID = 3, Name = "Macbook", Price = 700, Stock = 250, CategoryId = _CategoryIds[0] },
                new Product() { ID = 4, Name = "IPhone", Price = 300, Stock = 350, CategoryId = _CategoryIds[1] },
                new Product() { ID = 5, Name = "Samsung", Price = 250, Stock = 350, CategoryId = _CategoryIds[1] }
                );
        }
    }
}
