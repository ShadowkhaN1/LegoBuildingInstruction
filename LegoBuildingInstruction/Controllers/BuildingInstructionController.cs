using LegoBuildingInstruction.Models;
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

        public BuildingInstructionController(IBuildingInstructionRepository buildingInstructionRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
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
    }
}
