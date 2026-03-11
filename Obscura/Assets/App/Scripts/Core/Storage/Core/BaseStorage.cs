using System.Collections.Generic;

namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage<T> : IStorage<T>
    {
        private readonly HashSet<T> _items = new();
        
        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet(out T value)
        {
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}