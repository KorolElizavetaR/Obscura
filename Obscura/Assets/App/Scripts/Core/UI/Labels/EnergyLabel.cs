using System;
using App.Scripts.Core.Energy;
using App.Scripts.Core.Storage;
using TMPro;
using UnityEngine;

namespace App.Scripts.Core.UI.Labels
{
    public class EnergyLabel : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _energyCount;
        [SerializeField] private TextMeshProUGUI _timeToIncrease;
        [SerializeField] private EnergyConfig _energyConfig;
        
        private Storage.Entities.Energy _energyEntity;

        protected virtual void Awake()
        {
            EntitiesStorage.Instance.TryGet(out _energyEntity);
        }

        protected virtual void Update()
        {
            FormatCount();
            FormatTimeToIncrease();
        }

        private void FormatCount()
        {
            _energyCount.text = $"{_energyEntity.Count} / {_energyConfig.MaxCount}";
        }

        private void FormatTimeToIncrease()
        {
            if (_energyEntity.ReductionDateTime == default)
            {
                if (!_timeToIncrease.gameObject.activeSelf)
                {
                    return;
                }
                
                _timeToIncrease.gameObject.SetActive(false);
                return;
            }
            
            if (!_timeToIncrease.gameObject.activeSelf)
            {
                _timeToIncrease.gameObject.SetActive(true);
            }
            
            var dateTimeDiff = DateTime.Now - _energyEntity.ReductionDateTime;
            var elapsedSeconds = _energyConfig.RecoverSpeed - dateTimeDiff.Seconds;
            var elapsedMinutes = Mathf.FloorToInt(elapsedSeconds / 60);
            var elapsedSecondsWithoutMinutes = elapsedSeconds % 60;
            
            _timeToIncrease.text =$"{elapsedMinutes:00} : {elapsedSecondsWithoutMinutes:00}";
        }
    }
}