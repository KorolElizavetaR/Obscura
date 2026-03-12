using System;
using App.Scripts.Core.Storage;

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

        public void Reset()
        {
            _energyEntity.Count = _energyConfig.MaxCount;
            _energyEntity.ReductionDateTime = default;
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

        public bool TryIncrease(int value = 1)
        {
            var energyCount = _energyEntity.Count;

            if (energyCount >= _energyConfig.MaxCount)
            {
                _energyEntity.Count = _energyConfig.MaxCount;
                return false;
            }

            var datetimeDiff = DateTime.Now - _energyEntity.ReductionDateTime;

            if (datetimeDiff.Seconds < _energyConfig.RecoverSpeed)
            {
                return false;
            }
            
            energyCount = Math.Clamp(energyCount + value, 0, _energyConfig.MaxCount);

            _energyEntity.ReductionDateTime = energyCount < _energyConfig.MaxCount ? DateTime.Now : default;

            _energyEntity.Count = energyCount;
            return true;
        }
    }
}