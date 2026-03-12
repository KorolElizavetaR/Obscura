using System.Collections.Generic;
using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Levels : IEntity<LevelsDto>
    {
        public int CurrentLevelId { get; set; }
        public HashSet<int> CompletedLevels { get; set; } = new ();
        public int MaxLevelId { get; set; }

        public Levels() {}
        
        public Levels(LevelsDto dto)
        {
            CurrentLevelId = dto.CurrentLevelId;
            CompletedLevels = JsonFormatter.FromJson<HashSet<int>>(dto.CompletedLevels) ?? new HashSet<int>();
            MaxLevelId = dto.MaxLevelId;
        }
        
        public LevelsDto ToDto()
        {
            return new LevelsDto()
            {
                CurrentLevelId = CurrentLevelId,
                CompletedLevels = JsonFormatter.ToJson(CompletedLevels),
                MaxLevelId = MaxLevelId
            };
        }
    }
}