using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class EnergyDto : IDto
    {
        public int Count;
        public long ReductionTicks;
    }
}