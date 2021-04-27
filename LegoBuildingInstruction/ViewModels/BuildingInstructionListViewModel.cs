using LegoBuildingInstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class BuildingInstructionListViewModel
    {

        public IEnumerable<BuildingInstruction> BuildingInstructions { get; set; }

        public string CurrentCategory { get; set; }


    }
}
