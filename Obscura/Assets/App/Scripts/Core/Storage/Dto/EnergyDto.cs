using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class EnergyDto
    {
        private int _energy;
        private DateTime _reductionDateTime;

        public int Energy
        {
            get => _energy;
            set => _energy = value;
        }

        public DateTime ReductionDateTime
        {
            get => _reductionDateTime;
            set => _reductionDateTime = value;
        }
    }
}