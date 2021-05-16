using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class RateInstructionViewModel
    {
        [Required]
        public int BuildingInstructionId { get; set; }

        [Required]
        [Range(1, 5)]
        public int RatingValue { get; set; }

        public List<int> Values { get; set; } = new List<int> { 1, 2, 3, 4, 5 };


    }
}
