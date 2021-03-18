using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Core.Repositories;
using NLayerArchitecture.Core.Services;
using NLayerArchitecture.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IRepository<Category> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {       //parent sınıfında ctor var ve bunları alıyo, bunu inherite ettiğin için bu ctoru oluşturman ve seninde bunları alman lazım...
        }

        public async Task<Category> GetWithProductsById(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsById(categoryId);
        }
    }
}
