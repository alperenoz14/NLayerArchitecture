using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerArchitecture.API.DTO_s
{
    public class ProductWithCategoryDto: ProductDto
    {
        public CategoryDto Category { get; set; }
    }
}
