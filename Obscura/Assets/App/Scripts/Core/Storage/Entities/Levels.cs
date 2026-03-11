using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Levels : IEntity<LevelsDto>
    {
        public int CurrentLevelId { get; set; }

        public Levels() {}
        
        public Levels(LevelsDto dto)
        {
            CurrentLevelId = dto.CurrentLevelId;
        }
        
        public LevelsDto ToDto()
        {
            return new LevelsDto()
            {
                CurrentLevelId = CurrentLevelId
            };
        }
    }
}