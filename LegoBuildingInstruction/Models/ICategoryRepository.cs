using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface ICategoryRepository
    {

        Task<IEnumerable<Category>> AllCategoriesAsync();

        IEnumerable<Category> AllCategories { get; }

    }
}
