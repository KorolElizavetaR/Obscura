using App.Scripts.Core.Storage.Core;
using Extensions.Unity.PlayerPrefsEx;

namespace App.Scripts.Core.Storage
{
    public class EntitiesStorage : BaseStorage<EntitiesStorage>
    {
        public override void Load()
        {
            TryAdd(PlayerPrefsEx.GetJson<Entities.Level>(StorageContracts.CurrentLevel));
            TryAdd(PlayerPrefsEx.GetJson<Entities.Energy>(StorageContracts.Energy));
        }

        public override void Save()
        {
            if (TryGet(out Entities.Level level))
            {
                PlayerPrefsEx.SetJson(StorageContracts.CurrentLevel, level);
            }
            
            if (TryGet(out Entities.Energy energy))
            {
                PlayerPrefsEx.SetJson(StorageContracts.Energy, energy);
            }
        }
    }
}