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
    }
}