using System;

namespace App.Scripts.Core.Storage.Dto
{
    [Serializable]
    public sealed class EnergyDto
    {
        private int _energy;
        private DateTime _reductionDateTime;
    }
}