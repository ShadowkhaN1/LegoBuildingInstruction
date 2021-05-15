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

            return _appDbContext.BuildingInstructions.Include(u => u.User).Include(c => c.Category).FirstOrDefault(b => b.Id == id);
        }

        public async Task<BuildingInstruction> UpdateBuildingInstruction(BuildingInstruction updateBuildingInstruction)
        {

            var updateInstruction = _appDbContext.BuildingInstructions.FirstOrDefault(x => x.Id == updateBuildingInstruction.Id);


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
