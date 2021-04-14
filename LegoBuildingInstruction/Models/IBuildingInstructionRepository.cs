using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface IBuildingInstructionRepository
    {

        public IEnumerable<BuildingInstruction> AllBuildingInstructions { get; }


        BuildingInstruction GetBuildingInstructionById(int id);
    
    }
}
