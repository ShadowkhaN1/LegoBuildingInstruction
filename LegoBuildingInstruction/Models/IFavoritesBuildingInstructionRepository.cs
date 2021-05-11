using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public interface IFavoritesBuildingInstructionRepository
    {


        IEnumerable<FavoritesBuildingInstruction> AllFavoritesBuildingInstructions { get; } 

        IEnumerable<FavoritesBuildingInstruction> GetFavoritesBuildingInstructionsByUserId(string id);

        Task AddFavoritesBuildingInstruction(FavoritesBuildingInstruction newFavoritesBuildingInstruction);

        void DeleteFavoritesBuildingInstruction(FavoritesBuildingInstruction deleteFavoritesBuildingInstruction);
    }
}
