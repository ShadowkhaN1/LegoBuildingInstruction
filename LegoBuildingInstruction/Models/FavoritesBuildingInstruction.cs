using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class FavoritesBuildingInstruction
    {

        public int Id { get; set; }

        public int BuildingInstructionId { get; set; }
        public string UserId { get; set; }


        public BuildingInstruction BuildingInstruction { get; set; }
        public ApplicationUser User { get; set; }
    }
}
