using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLayerArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NLayerArchitecture.Data.Seeds
{
    public class CategorySeed : IEntityTypeConfiguration<Category>
    {
        private readonly int[] _CategoryIds;
        public CategorySeed(int [] ids)
        {
            _CategoryIds = ids;
        }

        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(
                new Category() { ID = _CategoryIds[0], Name = "Laptop" },
                new Category() { ID = _CategoryIds[1], Name = "Mobile" }
                );
        }
    }
}
