using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface IDifficultyRepository
    {
        IEnumerable<DifficultyLevel> AllDifficultyLevels { get; }
    }
}
