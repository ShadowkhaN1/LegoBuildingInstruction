using LegoBuildingInstruction.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace LegoBuildingInstruction.ViewModels
{
    public class HomeViewModel
    {

        public IEnumerable<BuildingInstruction> LegoBuildingInstructions { get; set; }


    }
}
