using LegoBuildingInstruction.Models;
using LegoBuildingInstruction.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class BuildingInstructionController : Controller
    {

        private readonly IBuildingInstructionRepository _buildingInstructionRepository;
        private readonly ICategoryRepository _categoryRepository;


        public BuildingInstructionController(IBuildingInstructionRepository buildingInstructionRepository, ICategoryRepository categoryRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
            _categoryRepository = categoryRepository;
        }


        public IActionResult Details(int id)
        {

            var buildingInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);



            if (buildingInstruction == null)
            {
                return NotFound();
            }

            return View(buildingInstruction);
        }


        public IActionResult List(string category)
        {

            IEnumerable<BuildingInstruction> buildingInstructions;
            string currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                currentCategory = "All Building Instructions";
                buildingInstructions = _buildingInstructionRepository.AllBuildingInstructions;

            }
            else
            {

                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;

                buildingInstructions = _buildingInstructionRepository.AllBuildingInstructions.Where(b => b.Category.CategoryName == category).OrderBy(b => b.Id);


            }


            BuildingInstructionListViewModel buildingInstructionListViewModel = new BuildingInstructionListViewModel
            {
                CurrentCategory = currentCategory,
                BuildingInstructions = buildingInstructions
            };

            return View(buildingInstructionListViewModel);
        }

    }
}
