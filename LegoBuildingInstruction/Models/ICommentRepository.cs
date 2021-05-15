using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface ICommentRepository
    {

        void AddComment(Comment comment);

        Comment UpdateComment(Comment editComment);

         Comment GetCommentById(int id);

        void DeleteComment(Comment deleteComment);

        IEnumerable<Comment> GetCommentsByBuildingInstruction(int buildingInstructionID);


    }
}
