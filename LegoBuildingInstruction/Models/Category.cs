using System.Collections.Generic;

namespace LegoBuildingInstruction.Models
{
    public class Category
    {

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<BuildingInstruction> BuilidingInstructions { get; set; }

    }
}