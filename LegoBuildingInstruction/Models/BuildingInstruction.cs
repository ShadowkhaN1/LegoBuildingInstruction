using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class BuildingInstruction
    {

        public int BuildingInstructionId { get; set; }

        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your instruction")]
        [Display(Name = "Name*")]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Description*")]
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string PdfInstructionUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        [Required]
        [Display(Name = "Category*")]
        public int CategoryId { get; set; }
        [Required]
        [Display(Name = "Category*")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "The number of pages must be greater than 0")]
        [Range(1, 1000)]
        [Display(Name = "Pages*")]
        public int Pages { get; set; }


        [Required]
        [Display(Name = "Sets of bricks used, example Mindstorms home core - 45544*")]
        public string Set { get; set; }
        public string ProgramUrl { get; set; }


        public List<Comment> Comments { get; set; }

        public List<RateInstruction> RateInstructions { get; set; }

        public ApplicationUser User { get; set; }

        public string UserId { get; set; }
    }

}
