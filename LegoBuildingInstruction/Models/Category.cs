using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LegoBuildingInstruction.Models
{
    public class Category
    {

        public int CategoryId { get; set; }

        [Required]
        [Display (Name ="Category")]
        public string CategoryName { get; set; }
        public List<BuildingInstruction> BuilidingInstructions { get; set; }

    }
}