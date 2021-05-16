using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class RateInstruction
    {
        public int Id { get; set; }

        public int RatingValue { get; set; }

        public int BuildingInstructionId { get; set; }
        public string UserId { get; set; }

        [NotMapped]
        public List<SelectListItem> Values { get; } = new List<SelectListItem> {
            new SelectListItem {Text = "5", Value = "5" },
            new SelectListItem {Text = "4", Value = "4" },
            new SelectListItem {Text = "3", Value = "3" },
            new SelectListItem {Text = "2", Value = "2" },
            new SelectListItem {Text = "1", Value = "1" },
        };

        public BuildingInstruction BuildingInstruction { get; set; }
        public ApplicationUser User { get; set; }


    }
}
