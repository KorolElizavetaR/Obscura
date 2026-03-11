using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class EnergyDto
    {
        private int _count;
        private DateTime _reductionDateTime;

        public int Count
        {
            get => _count;
            set => _count = value;
        }

        public DateTime ReductionDateTime
        {
            get => _reductionDateTime;
            set => _reductionDateTime = value;
        }
    }
}