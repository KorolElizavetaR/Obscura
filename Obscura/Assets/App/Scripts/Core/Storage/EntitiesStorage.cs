using App.Scripts.Core.Storage.Core;
using App.Scripts.Core.Storage.Dto;
using App.Scripts.Core.Storage.Entities;
using Extensions.Unity.PlayerPrefsEx;

namespace App.Scripts.Core.Storage
{
    public class EntitiesStorage : BaseStorage<EntitiesStorage>
    {
        public override void Load()
        {
            TryAdd(new Level(PlayerPrefsEx.GetJson(StorageContracts.CurrentLevel, new LevelDto())));
            TryAdd(new Entities.Energy(PlayerPrefsEx.GetJson(StorageContracts.Energy, new EnergyDto())));
            TryAdd(new ButtonTogglers(PlayerPrefsEx.GetJson(StorageContracts.ButtonTogglers, new ButtonTogglersDto())));
        }

        public override void Save()
        {
            if (TryGet(out Entities.Level level))
            {
                PlayerPrefsEx.SetJson(StorageContracts.CurrentLevel, level.ToDto());
            }
            
            if (TryGet(out Entities.Energy energy))
            {
                PlayerPrefsEx.SetJson(StorageContracts.Energy, energy.ToDto());
            }

            if (TryGet(out Entities.ButtonTogglers buttonTogglers))
            {
                PlayerPrefsEx.SetJson(StorageContracts.ButtonTogglers, buttonTogglers.ToDto());
            }
        }
    }
}