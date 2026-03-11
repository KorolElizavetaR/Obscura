using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Levels : IEntity<LevelsDto>
    {
        public int Id { get; set; }

        public Levels() {}
        
        public Levels(LevelsDto dto)
        {
            Id = dto.Id;
        }
        
        public LevelsDto ToDto()
        {
            return new LevelsDto();
        }
    }
}