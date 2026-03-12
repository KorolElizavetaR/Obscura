using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace App.Scripts.Core.Utils
{
    public static class Finder
    {
        private class Logger : ILogDistributor
        {
            public string DistributorName => nameof(Finder);
        }

        private static readonly Logger _logger = new ();
        
        public static bool TryFind<T>(out List<T> result, bool logging = true) where T : Component
        {
            result = Object.FindObjectsByType<T>(FindObjectsSortMode.None).ToList();

            var anyComponents = result.Any();
            
            if (anyComponents && logging)
            {
                _logger.LogWarning($"No components of type {typeof(T).Name} found");
            }
            
            return anyComponents;
        }
    }
}