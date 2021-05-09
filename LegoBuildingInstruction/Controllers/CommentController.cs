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
        public IActionResult AddComment(Comment comment)
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




        [HttpGet]
        [Authorize]
        public IActionResult EditComment(int id)
        {

            var editComment = _commentRepository.GetCommentById(id);

            if (editComment == null)
            {
                return NotFound();
            }
            else
            {
                return View(editComment);
            }


        }



        [HttpPost]
        [Authorize]
        public IActionResult EditComment(Comment comment)
        {


            _commentRepository.UpdateComment(comment);


            string url = $@"/BuildingInstruction/Details/{comment.BuildingInstructionId}";


            return Redirect(url);
        }


        public  IActionResult DeleteComment(int id)
        {

            var deleteComment = _commentRepository.GetCommentById(id);


            if (deleteComment != null)
            {


                _commentRepository.DeleteComment(deleteComment);

                string url = $@"/BuildingInstruction/Details/{deleteComment.BuildingInstructionId}";

                return Redirect(url);
            }

            return View("Index", "Home");
        }



    }
}
