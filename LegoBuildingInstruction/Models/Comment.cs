using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class Comment
    {

        public int CommentId { get; set; }
        public string Message { get; set; }

        public DateTime CreatedAt { get; set; }


        public int BuildingInstructionId { get; set; }
        public BuildingInstruction BuildingInstruction { get; set; }


        public ApplicationUser User { get; set; }

        public string UserId { get; set; }


    }
}
