using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LegoBuildingInstruction.Models
{
    public class DifficultyRepository : IDifficultyRepository
    {
        private readonly AppDbContext _appDbContext;

        public DifficultyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<DifficultyLevel> AllDifficultyLevels => _appDbContext.DifficultyLevels;
    }
}
