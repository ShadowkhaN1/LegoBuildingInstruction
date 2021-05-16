using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface IRateInstructionRepository
    {
        IEnumerable<RateInstruction> AllRateInstructions { get; }
        Task RateInstruction(RateInstruction rateInstruction);
        IEnumerable<RateInstruction> GetAllRatesByBuildingInstructionId(int id);
    }
}
