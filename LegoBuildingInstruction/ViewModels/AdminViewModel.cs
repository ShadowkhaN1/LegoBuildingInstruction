using LegoBuildingInstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class AdminViewModel
    {
        public List<ApplicationUser> ApplicationUsers { get; set; }
        public List<BuildingInstruction> BuildingInstructions { get; set; }

    }
}
