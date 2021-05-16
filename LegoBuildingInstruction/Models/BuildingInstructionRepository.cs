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

        public IEnumerable<BuildingInstruction> AllBuildingInstructions => _appDbContext.BuildingInstructions.Include(c => c.Category).Include(u => u.User).Include(r => r.RateInstructions);


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

            return _appDbContext.BuildingInstructions.Include(u => u.User).Include(c => c.Category).Include(r => r.RateInstructions).FirstOrDefault(b => b.BuildingInstructionId == id);
        }

        public async Task<BuildingInstruction> UpdateBuildingInstruction(BuildingInstruction updateBuildingInstruction)
        {

            var updateInstruction = _appDbContext.BuildingInstructions.FirstOrDefault(x => x.BuildingInstructionId == updateBuildingInstruction.BuildingInstructionId);


            if (updateInstruction != null)
            {

                updateInstruction.ImageUrl = updateBuildingInstruction.ImageUrl;
                updateInstruction.LongDescription = updateBuildingInstruction.LongDescription;
                updateInstruction.Name = updateBuildingInstruction.Name;
                updateInstruction.Pages = updateBuildingInstruction.Pages;
                updateInstruction.PdfInstructionUrl = updateBuildingInstruction.PdfInstructionUrl;
                updateInstruction.Set = updateBuildingInstruction.Set;
                updateInstruction.VideoUrl = updateBuildingInstruction.VideoUrl;
                updateInstruction.ProgramUrl = updateBuildingInstruction.ProgramUrl;
                updateInstruction.CategoryId = updateBuildingInstruction.CategoryId;


                await _appDbContext.SaveChangesAsync();

            }

            return updateInstruction;
        }
    }
}
