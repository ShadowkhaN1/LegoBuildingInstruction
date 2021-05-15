using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class BuildingInstructionCreateViewModel
    {


        [StringLength(50, MinimumLength = 5)]
        [Required(ErrorMessage = "Please enter the title of your instruction")]
        [Display(Name ="Name*")]
        public string Name { get; set; }


        [Required]
        [StringLength(200)]
        [Display(Name = "Description*")]
        public string LongDescription { get; set; }


        [Required]
        [Display(Name = "Category*")]
        public int CategoryId { get; set; }

        
        [Required(ErrorMessage = "Please upload the picture in jpg or .png format")]
        [Display(Name = "Upload picture of the model*")]
        public IFormFile InstructionImage { get; set; }
        public string InstructionImageUrl { get; set; }

        [Required]
        [Display(Name = "Upload your instruction in pdf format*")]
        public IFormFile InstructionPdf { get; set; }
        public string InstructionPdfUrl { get; set; }

        [Required]
        [Display(Name = "Upload video in .mp4 format*")]
        public IFormFile InstructionVideo { get; set; }
        public string InstructionVideoURL { get; set; }

        [Required(ErrorMessage = "The number of pages must be greater than 0")]
        [Range(1, 1000)]
        [Display(Name = "Pages*")]
        public int Pages { get; set; }

        [Display(Name = "Sets of bricks used, example Mindstorms home core - 45544*")]
        public string Set { get; set; }


        [Display(Name = "Upload program in .ev3 format for Mindstorms")]
        public IFormFile Program { get; set; }
        public string ProgramUrl { get; set; }

    }
}
