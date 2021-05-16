using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class RateInstructionRepository : IRateInstructionRepository
    {
        private readonly AppDbContext _appDbContext;

        public RateInstructionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<RateInstruction> AllRateInstructions => _appDbContext.RateInstructions.Include(x => x.BuildingInstruction).Include(x => x.User);

        public IEnumerable<RateInstruction> GetAllRatesByBuildingInstructionId(int id)
        {
            return _appDbContext.RateInstructions.Where(x => x.BuildingInstructionId == id).Include(x => x.BuildingInstruction).Include(x => x.User);

        }

        public async Task RateInstruction(RateInstruction rateInstruction)
        {
            var editRating = await _appDbContext.RateInstructions.FirstOrDefaultAsync(x => x.BuildingInstructionId == rateInstruction.BuildingInstructionId
                                    && x.UserId == rateInstruction.UserId);

            if (editRating != null)
            {
                editRating.RatingValue = rateInstruction.RatingValue;
            }
            else
            {
                await _appDbContext.RateInstructions.AddAsync(rateInstruction);

            }


            await _appDbContext.SaveChangesAsync();
        }
    }
}
