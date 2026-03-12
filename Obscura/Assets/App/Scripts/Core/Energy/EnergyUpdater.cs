using App.Scripts.Core.Storage;
using UnityEngine;

namespace App.Scripts.Core.Energy
{
    public class EnergyUpdater : MonoBehaviour
    {
        [SerializeField] private EnergyConfig _energyConfig;
        private Storage.Entities.Energy _energyEntity;
        
        protected virtual void Awake()
        {
            EntitiesStorage.Instance.TryGet(out _energyEntity);
        }
    }
}