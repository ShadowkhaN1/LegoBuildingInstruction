using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class CommentRepository : ICommentRepository
    {

        private readonly AppDbContext _appDbContext;

        public CommentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void AddComment(Comment comment)
        {
            _appDbContext.Comments.Add(comment);
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Comment> GetCommentsByBuildingInstruction(int buildingInstructionId) 
            => _appDbContext.Comments.Include(u => u.User).Where(b => b.BuildingInstructionId == buildingInstructionId);


        public Comment GetCommentById(int id)
        {
           return  _appDbContext.Comments.FirstOrDefault(c => c.CommentId == id);
        }

        public void UpdateComment(Comment updateComment)
        {

            var editComment = _appDbContext.Comments.FirstOrDefault(c => c.CommentId == updateComment.CommentId);


            if (editComment != null)
            {
                editComment.CreatedAt = DateTime.Now;
                editComment.Message = updateComment.Message;

                _appDbContext.SaveChanges();

            }


        }

        public void DeleteComment(Comment deleteComment)
        {

            _appDbContext.Comments.Remove(deleteComment);
            _appDbContext.SaveChanges();
        }
    }
}
