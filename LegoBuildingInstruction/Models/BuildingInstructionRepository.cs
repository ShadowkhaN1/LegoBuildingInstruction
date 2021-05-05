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

        public IEnumerable<BuildingInstruction> AllBuildingInstructions => _appDbContext.BuildingInstructions.Include(c => c.Category).Include(d => d.DifficultyLevel).Include(u => u.User);

        public IEnumerable<BuildingInstruction> TopRatedBuildingInstructions => _appDbContext.BuildingInstructions.OrderByDescending(b => b.Rating);

        public BuildingInstruction GetBuildingInstructionById(int id)
        {

            return _appDbContext.BuildingInstructions.Include(u => u.User).FirstOrDefault(b => b.Id == id);
        }
    }
}
