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
            _appDbContext.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetCommentsByBuildingInstruction(int buildingInstructionId) 
            => _appDbContext.Comments.Include(u => u.User).Where(b => b.BuildingInstructionId == buildingInstructionId);
    }
}
