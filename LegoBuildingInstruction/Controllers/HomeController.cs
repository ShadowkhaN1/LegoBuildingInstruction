using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LegoBuildingInstruction.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildingInstructionRepository _buildingInstructionRepository;
        private readonly IDifficultyRepository _difficultyRepository;

        public HomeController(IBuildingInstructionRepository buildingInstructionRepository, IDifficultyRepository difficultyRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
            _difficultyRepository = difficultyRepository;
        }

        public IActionResult Index()
        {


            var homeViewModel = new HomeViewModel
            {
                TopRatedLegoBuildingInstructions = _buildingInstructionRepository.TopRatedBuildingInstructions
            };

            return View(homeViewModel);
        }
    }
}
