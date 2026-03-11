using System.Collections.Generic;
using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Levels : IEntity<LevelsDto>
    {
        public int CurrentLevelId { get; set; }
        public HashSet<int> CompletedLevels { get; set; } = new ();

        public Levels() {}
        
        public Levels(LevelsDto dto)
        {
            CurrentLevelId = dto.CurrentLevelId;
            CompletedLevels = dto.CompletedLevels;
        }
        
        public LevelsDto ToDto()
        {
            return new LevelsDto()
            {
                CurrentLevelId = CurrentLevelId,
                CompletedLevels = CompletedLevels
            };
        }
    }
}