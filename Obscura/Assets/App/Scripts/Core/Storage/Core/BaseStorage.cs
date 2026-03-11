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
            throw new System.NotImplementedException();
        }

        public void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}