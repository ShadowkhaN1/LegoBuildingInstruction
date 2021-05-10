using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class BuildingInstructionRepository : IBuildingInstructionRepository
    {
        private readonly AppDbContext _appDbContext;

        public BuildingInstructionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<BuildingInstruction> AllBuildingInstructions => _appDbContext.BuildingInstructions.Include(c => c.Category).Include(u => u.User);

        public IEnumerable<BuildingInstruction> TopRatedBuildingInstructions => _appDbContext.BuildingInstructions.OrderByDescending(b => b.Rating);

        public async Task AddNewBuildingInstructionAsync(BuildingInstruction newBuildingInstruction)
        {
            await _appDbContext.BuildingInstructions.AddAsync(newBuildingInstruction);
            await _appDbContext.SaveChangesAsync();
        }

        public void DeleteInstruction(BuildingInstruction deleteInstruction)
        {

            _appDbContext.BuildingInstructions.Remove(deleteInstruction);
            _appDbContext.SaveChanges();
        }

        public BuildingInstruction GetBuildingInstructionById(int id)
        {

            return _appDbContext.BuildingInstructions.Include(u => u.User).FirstOrDefault(b => b.Id == id);
        }
    }
}
