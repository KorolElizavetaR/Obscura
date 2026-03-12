using App.Scripts.Core.Storage;
using UnityEngine;

namespace App.Scripts.Core.UI.button
{
    public class BlockButtonOnZeroEnergy : MonoBehaviour
    {
        private Storage.Entities.Energy _energyEntity;

        protected virtual void Awake()
        {
            EntitiesStorage.Instance.TryGet(out _energyEntity);
        }
    }
}