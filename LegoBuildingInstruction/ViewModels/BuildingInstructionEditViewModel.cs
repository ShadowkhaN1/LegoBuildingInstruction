using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.ViewModels
{
    public class BuildingInstructionEditViewModel : BuildingInstructionCreateViewModel
    {
        public int BuildingInstructionId { get; set; }

    }
}
