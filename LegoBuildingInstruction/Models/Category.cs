using System.Collections.Generic;

namespace LegoBuildingInstruction.Models
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public List<BuildingInstruction> BuilidingInstructions { get; set; }

    }
}