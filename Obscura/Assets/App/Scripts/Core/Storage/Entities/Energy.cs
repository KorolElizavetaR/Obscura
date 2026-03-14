using System;
using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public sealed class Energy : IEntity<EnergyDto>
    {
        public int Count { get; set; }
        public DateTime ReductionDateTime { get; set; }

        public Energy() {}
        
        public Energy(EnergyDto dto)
        {
            Count = dto.Count;
            ReductionDateTime = new DateTime(dto.ReductionTicks);
        }
        
        public EnergyDto ToDto()
        {
            return new EnergyDto()
            {
                Count = Count,
                ReductionTicks = ReductionDateTime.Ticks
            };
        }
    }
}