using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface ICommentRepository
    {

        void AddComment(Comment comment);

        IEnumerable<Comment> GetCommentsByBuildingInstruction(int buildingInstructionID);

    }
}
