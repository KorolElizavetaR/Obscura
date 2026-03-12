using UnityEngine;

namespace App.Scripts.Core.Energy
{
    public class EnergyUpdater : MonoBehaviour
    {
        [SerializeField] private EnergyConfig _energyConfig;
        
        public EnergyOperations EnergyOperations { get; private set; }
        
        protected virtual void Awake()
        {
            EnergyOperations = new EnergyOperations(_energyConfig);

            if (_energyConfig.ResetOnStart)
            {
                EnergyOperations.Reset();
            }
        }

        protected virtual void Update()
        {
            EnergyOperations.TryIncrease();
        }
    }
}