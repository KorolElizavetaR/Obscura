using System;
using App.Scripts.Core.Storage;
using UnityEngine;

namespace App.Scripts.Core.Energy
{
    public class EnergyOperations
    {
        private EnergyConfig _energyConfig;
        private Storage.Entities.Energy _energyEntity;
        
        public EnergyOperations(EnergyConfig energyConfig)
        {
            _energyConfig = energyConfig;
            EntitiesStorage.Instance.TryGet(out _energyEntity);
        }

        public bool TryDecrease(int value = 1)
        {
            var energyCount = _energyEntity.Count;
            
            if (energyCount <= 0)
            {
                _energyEntity.Count = 0;
                return false;
            }

            if (_energyEntity.ReductionDateTime == default)
            {
                _energyEntity.ReductionDateTime = DateTime.Now;
            }

            _energyEntity.Count = Math.Clamp(energyCount - value, 0, _energyConfig.MaxCount);
            return true;
        }
    }
}