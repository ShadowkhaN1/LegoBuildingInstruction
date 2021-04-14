﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class BuildingInstruction
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImageUrl { get; set; }
        public string PdfInstructionUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public string VideoUrl { get; set; }
        public Category Category { get; set; }
        public int Pages { get; set; }
        public string Set { get; set; }
        public string ProgramUrl { get; set; }
        public int Rating { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }

    }
}
