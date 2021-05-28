using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{


    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBuildingInstructionRepository _buildingInstructionRepository;

        public AdminController(UserManager<ApplicationUser> userManager,
            IBuildingInstructionRepository buildingInstructionRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
            _userManager = userManager;
        }


        public IActionResult Index()
        {

            var allUsers = _userManager.Users.ToList();
            var allBuildingInstructions = _buildingInstructionRepository.AllBuildingInstructions.ToList();

            AdminViewModel adminViewModel = new AdminViewModel()
            {
                ApplicationUsers = allUsers,
                BuildingInstructions = allBuildingInstructions
            };


            return View(adminViewModel);
        }


        public async Task<IActionResult> DeleteUser(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);


            return RedirectToAction("Index");
        }
    }
}
