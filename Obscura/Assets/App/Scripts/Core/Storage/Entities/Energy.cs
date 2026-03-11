using System;
using App.Scripts.Core.Storage.Dto;

namespace App.Scripts.Core.Storage.Entities
{
    public sealed class Energy : IEntity<EnergyDto>
    {
        public int Count { get; set; }
        public DateTime ReductionDateTime { get; set; }
        
        public EnergyDto ToDto()
        {
            return new EnergyDto()
            {
                Count = Count,
                ReductionDateTime = ReductionDateTime
            };
        }
    }
}