using UnityEngine;

namespace App.Scripts.Core.Storage.Core
{
    public class BaseMonoStorage<T> : MonoBehaviour, IStorage
    {
        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet<T1>(out T1 value)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}