using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage : IStorage, ILogDistributor
    {
        public string DistributorName => GetType().Name;
        private readonly Dictionary<Type, object> _storage = new ();
        
        private static BaseStorage _instance;

        public static BaseStorage GetInstance()
        {
            _instance ??= new BaseStorage();
            return _instance;
        }
        
        private BaseStorage()
        {
            Load();
            Application.exitCancellationToken.Register(Save);
        }
        
        public virtual void Load()
        {
            throw new System.NotImplementedException();
        }

        public bool TryGet<T>(out T value)
        {
            value = default;
            
            if (!_storage.TryGetValue(typeof(T), out var foundValue))
            {
                this.LogError($"No storage found for type {typeof(T)}");
                return false;
            }

            if (foundValue is not T valueConverted)
            {
                this.LogError($"Storage found value for type {typeof(T)} but it not the same");
                _storage.Remove(typeof(T));
                return false;
            }

            value = valueConverted;

            return true;
        }

        public virtual void Save()
        {
            throw new System.NotImplementedException();
        }
    }
}