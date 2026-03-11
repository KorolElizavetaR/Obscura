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
    }
}