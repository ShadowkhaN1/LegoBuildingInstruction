using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Components
{
    public class CommentList : ViewComponent
    {

        private readonly ICommentRepository _commentRepository;

        public CommentList(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }


        public IViewComponentResult Invoke(int buildingInstructionId)
        {
            var comments = _commentRepository.GetCommentsByBuildingInstruction(buildingInstructionId).OrderByDescending(o => o.CreatedAt);

            return View(comments);
        }

    }
}
