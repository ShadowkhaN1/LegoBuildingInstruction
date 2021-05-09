using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class ApplicationUser : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public List<Comment> Comments { get; set; }

        public List<BuildingInstruction> BuildingInstructions { get; set; }
    }
}
