using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public class Level : IEntity<LevelDto>
    {
        public int Id { get; set; }
        
        public LevelDto ToDto()
        {
            return new LevelDto();
        }
    }
}