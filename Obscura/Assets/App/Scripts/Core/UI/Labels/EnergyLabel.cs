using App.Scripts.Core.Energy;
using App.Scripts.Core.Storage;
using TMPro;
using UnityEngine;

namespace App.Scripts.Core.UI.Labels
{
    public class EnergyLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _energyCount;
        [SerializeField] private TextMeshPro _timeToIncrease;
        [SerializeField] private EnergyConfig _energyConfig;
        
        private Storage.Entities.Energy _energyEntity;

        protected virtual void Awake()
        {
            EntitiesStorage.Instance.TryGet(out _energyEntity);
        }
    }
}