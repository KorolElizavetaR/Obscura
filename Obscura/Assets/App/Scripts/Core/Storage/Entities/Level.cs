using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Level : IEntity<LevelDto>
    {
        public int Id { get; set; }

        public Level() {}
        
        public Level(LevelDto dto)
        {
            Id = dto.Id;
        }
        
        public LevelDto ToDto()
        {
            return new LevelDto();
        }
    }
}