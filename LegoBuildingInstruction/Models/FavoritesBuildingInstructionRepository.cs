using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class FavoritesBuildingInstructionRepository : IFavoritesBuildingInstructionRepository
    {
        private readonly AppDbContext _appDbContext;

        public FavoritesBuildingInstructionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<FavoritesBuildingInstruction> AllFavoritesBuildingInstructions => _appDbContext.FavoritesCategories.Include(x => x.BuildingInstruction)
            .Include(x => x.BuildingInstruction.Category).Include(x => x.BuildingInstruction.User).Include(x => x.User);

        public async Task AddFavoritesBuildingInstruction(FavoritesBuildingInstruction newFavoritesBuildingInstruction)
        {

            

            await _appDbContext.FavoritesCategories.AddAsync(newFavoritesBuildingInstruction);
            await _appDbContext.SaveChangesAsync();
        }

        public void DeleteFavoritesBuildingInstruction(FavoritesBuildingInstruction deleteFavoritesBuildingInstruction)
        {
            _appDbContext.Remove(deleteFavoritesBuildingInstruction);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<FavoritesBuildingInstruction> GetFavoritesBuildingInstructionsByUserId(string id)
        {

            return _appDbContext.FavoritesCategories.Include(x => x.BuildingInstruction).Include(x => x.BuildingInstruction.Category)
                .Include(x => x.BuildingInstruction.User).Include(x => x.User).Where(x => x.UserId == id);

        }


    }
}
