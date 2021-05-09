using LegoBuildingInstruction.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Controllers
{
    public class InstructionController : Controller
    {


        private readonly IBuildingInstructionRepository _buildingInstructionRepository;

        public InstructionController(IBuildingInstructionRepository buildingInstructionRepository)
        {
            _buildingInstructionRepository = buildingInstructionRepository;
        }


        [Authorize]
        public IActionResult Instruction(int id)
        {

            var buildingInstruction = _buildingInstructionRepository.GetBuildingInstructionById(id);

            return View(buildingInstruction);
        }


        //[Authorize]
        //[HttpPost]
        //public IActionResult Add()
        //{


            
        //}


    }
}
