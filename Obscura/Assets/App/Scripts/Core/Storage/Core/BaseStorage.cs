using System;
using System.Collections.Generic;

namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage : IStorage
    {
        private readonly Dictionary<Type, object> _storage = new ();
        
        public void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet<T>(out T value)
        {
            value = default;
            
            if (!_storage.TryGetValue(typeof(T), out var foundValue))
            {
                return false;
            }

            if (foundValue is not T valueConverted)
            {
                _storage.Remove(typeof(T));
                return false;
            }

            value = valueConverted;

            return true;
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}