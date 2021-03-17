using NLayerArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.Repositories
{
    interface IProductRepository: IRepository<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);
    }
}
