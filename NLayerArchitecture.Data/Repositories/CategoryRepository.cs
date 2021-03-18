using Microsoft.EntityFrameworkCore;
using NLayerArchitecture.Core.Entities;
using NLayerArchitecture.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NLayerArchitecture.Data.Repositories
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private AppDbContext _appDbContext { get => _context as AppDbContext; }     //???
                                                                                    //parent sınıftaki aldığım _context'i,tablolara erişebilmek için appdbcontexte çeviriyorum.
        public CategoryRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<Category> GetWithProductsById(int categoryId)
        {
            return await _appDbContext.Categories.Include(x => x.Products).SingleOrDefaultAsync(x => x.ID == categoryId);
            //idsi gönderdiğim idye eişt olan kategorileri include ettiği products ile birlikte getir...
        }
    }
}
