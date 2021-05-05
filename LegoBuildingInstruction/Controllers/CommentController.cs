using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class CommentController : Controller
    {


        private readonly ICommentRepository _commentRepository;
        private readonly UserManager<ApplicationUser> _userManager;


        public CommentController(ICommentRepository commentRepository, UserManager<ApplicationUser> userManager)
        {
            _commentRepository = commentRepository;
            _userManager = userManager;
        }


        [HttpPost]
        [Authorize]
        public IActionResult Form(Comment comment)
        {



            var newComment = new Comment
            {
                BuildingInstructionId = comment.BuildingInstructionId,
                CreatedAt = DateTime.Now,
                Message = comment.Message,
                UserId = _userManager.GetUserId(HttpContext.User)

            };

            _commentRepository.AddComment(newComment);

            string url = $@"/BuildingInstruction/Details/{comment.BuildingInstructionId}";


            return Redirect(url);
        }


    }
}
