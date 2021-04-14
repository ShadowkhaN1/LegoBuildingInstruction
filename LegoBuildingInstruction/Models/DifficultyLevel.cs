using System.Collections.Generic;

namespace LegoBuildingInstruction.Models
{
    public class DifficultyLevel
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public List<BuildingInstruction> BuildingInstructions { get; set; }
    }
}