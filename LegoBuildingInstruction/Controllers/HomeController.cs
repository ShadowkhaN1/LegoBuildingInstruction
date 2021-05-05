using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LegoBuildingInstruction.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBuildingInstructionRepository _buildingInstructionRepository;

        public HomeController(IBuildingInstructionRepository buildingInstructionRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
        }

        public IActionResult Index()
        {


            var homeViewModel = new HomeViewModel
            {
                LegoBuildingInstructions = _buildingInstructionRepository.AllBuildingInstructions
            };

            return View(homeViewModel);
        }
    }
}
