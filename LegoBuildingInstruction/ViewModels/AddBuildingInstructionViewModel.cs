using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class AddBuildingInstructionViewModel
    {
        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your instruction")]
        public string Name { get; set; }

        public string ShortDescription { get; set; }

        [Required]
        [StringLength(130)]
        [Display(Name = "Description")]
        public string LongDescription { get; set; }


        public string ImageThumbnailUrl { get; set; }

        [Required(ErrorMessage = "Please enter video url")]
        [Display(Name = "Video url from youtube, example https://youtu.be/lRVrWwEMntQ")]
        public string VideoUrl { get; set; }
        public DateTime CreatedAt { get; set; }


        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        
        public List<Category> Categories { get; set; }

        [Required(ErrorMessage = "Please upload the picture")]
        [Display(Name = "Upload picture of the model")]
        public IFormFile InstructionImage { get; set; }
        public string InstructionImageUrl { get; set; }

        [Required]
        [Display(Name = "Upload your instruction in pdf format")]
        public IFormFile InstructionPdf { get; set; }
        public string InstructionPdfUrl { get; set; }

        [Required]
        [Display(Name = "Upload video in .mp4 format")]
        public IFormFile InstructionVideo { get; set; }
        public string InstructionVideoURL { get; set; }

        [Required(ErrorMessage = "The number of pages must be greater than 0")]
        [Range(1, 1000)]
        public int Pages { get; set; }

        [Display(Name = "Set number, example for Mindstorms home - 45544")]
        public string Set { get; set; }

        public IFormFile Program { get; set; }
        public string ProgramUrl { get; set; }


        public ApplicationUser User { get; set; }

        public string UserId { get; set; }


    }
}
