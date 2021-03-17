using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecture.Data.Configurations
{
    class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).UseIdentityColumn(); //ID property means identity column in db table...
            builder.Property(x => x.Name).IsRequired().HasMaxLength(200);           //name property required!!...
            builder.Property(x => x.Stock).IsRequired();
            builder.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(x => x.InnerBarcode).HasMaxLength(50);

            builder.ToTable("Products");
            
        }
    }
}
