using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class CategoryRepository : ICategoryRepository
    {

        private readonly AppDbContext _appDbContext;

        public CategoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<IEnumerable<Category>> AllCategoriesAsync()
        {


         return  await _appDbContext.Categories.Include(c => c.BuilidingInstructions).ToListAsync();
        }

        public  IEnumerable<Category> AllCategories  =>  _appDbContext.Categories.Include(c => c.BuilidingInstructions);
        
    }
}
