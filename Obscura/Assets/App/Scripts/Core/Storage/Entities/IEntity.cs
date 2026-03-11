using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public interface IEntity<out T> where T : IDto
    {
        T ToDto();
    }
}