using App.Scripts.Core.Energy;
using TMPro;
using UnityEngine;

namespace App.Scripts.Core.UI.Labels
{
    public class EnergyLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshPro _energyCount;
        [SerializeField] private TextMeshPro _timeToIncrease;
        
        private EnergyConfig _energyConfig;
        private Storage.Entities.Energy _energyEntity;
    }
}