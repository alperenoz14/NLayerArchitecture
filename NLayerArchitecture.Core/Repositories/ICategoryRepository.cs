using NLayerArchitecture.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Core.Repositories
{
    interface ICategoryRepository: IRepository<Category>
    {
        Task<Category> GetWithProductsById(int categoryId);
    }
}
