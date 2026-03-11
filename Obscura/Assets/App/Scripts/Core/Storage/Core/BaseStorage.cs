using System;
using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Core.Storage.Core
{
    public class BaseStorage<T> : IStorage, ILogDistributor 
        where T : BaseStorage<T>, new ()
    {
        public string DistributorName => GetType().Name;
        private readonly Dictionary<Type, object> _storage = new ();
        
        private static T _instance;
        public static T Instance => _instance ??= new T();

        protected BaseStorage()
        {
            Load();
            Application.exitCancellationToken.Register(Save);
        }
        
        public virtual void Load() {}

        public bool TryGet<TT>(out TT value)
        {
            value = default;
            
            if (!_storage.TryGetValue(typeof(TT), out var foundValue))
            {
                this.LogWarning($"No storage found for type {typeof(TT)}");
                return false;
            }

            if (foundValue is not TT valueConverted)
            {
                this.LogWarning($"Storage found value for type {typeof(TT)} but it not the same");
                _storage.Remove(typeof(TT));
                return false;
            }

            value = valueConverted;

            return true;
        }

        public bool TryAdd<TT>(TT value)
        {
            throw new NotImplementedException();
        }

        public virtual void Save() {}
    }
}