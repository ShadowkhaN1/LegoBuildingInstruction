using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class FavoritesBuildingInstructionController : Controller
    {
        private readonly IFavoritesBuildingInstructionRepository _favoritesBuildingInstructionRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IBuildingInstructionRepository _buildingInstructionRepository;



        public FavoritesBuildingInstructionController(IFavoritesBuildingInstructionRepository favoritesBuildingInstructionRepository, IBuildingInstructionRepository buildingInstructionRepository, UserManager<ApplicationUser> userManager)
        {
            _favoritesBuildingInstructionRepository = favoritesBuildingInstructionRepository;
            _userManager = userManager;
            _buildingInstructionRepository = buildingInstructionRepository;
        }


        [Authorize]
        public async Task<IActionResult> AddFavoritesBuildingInstruction(int buildingInstructionId)
        {



            var buildingInstruction = _buildingInstructionRepository.AllBuildingInstructions.FirstOrDefault(x => x.BuildingInstructionId == buildingInstructionId);

            if (buildingInstruction == null)
            {
                return NotFound();
            }

            ApplicationUser user = await _userManager.GetUserAsync(HttpContext.User);



            if (User == null)
            {
                return NotFound();
            }


            var deleteFavoritesBuildingInstruction = _favoritesBuildingInstructionRepository.AllFavoritesBuildingInstructions
                .SingleOrDefault(x => x.UserId == _userManager.GetUserId(HttpContext.User) && x.BuildingInstructionId == buildingInstructionId);

            if (deleteFavoritesBuildingInstruction != null)
            {
                return RedirectToAction("DeleteFavoritesBuildingInstruction", new { deleteFavoritesBuildingInstructionId = deleteFavoritesBuildingInstruction.Id });
            }

            var newFavoritesBuildingInstruction = new FavoritesBuildingInstruction
            {
                BuildingInstruction = buildingInstruction,
                User = user
            };

            await _favoritesBuildingInstructionRepository.AddFavoritesBuildingInstruction(newFavoritesBuildingInstruction);


            return RedirectToAction("Details", "BuildingInstruction", new { id = buildingInstruction.BuildingInstructionId });
        }

        public IActionResult DeleteFavoritesBuildingInstruction(int deleteFavoritesBuildingInstructionId)
        {

            var deleteFavorites = _favoritesBuildingInstructionRepository.AllFavoritesBuildingInstructions.SingleOrDefault(x => x.Id == deleteFavoritesBuildingInstructionId);


            if (deleteFavorites == null)
            {
                return NotFound();
            }

            _favoritesBuildingInstructionRepository.DeleteFavoritesBuildingInstruction(deleteFavorites);


            return RedirectToAction("Details", "BuildingInstruction", new { id = deleteFavorites.BuildingInstructionId });
        }

    }
}
