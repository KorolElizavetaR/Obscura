using UnityEngine;

namespace App.Scripts.Core.Storage
{
    public class StorageConfig : ScriptableObject
    {
        [SerializeField] private string _currentlevelIdentifier = "level";
        
        public string CurrentLevelIdentifier => _currentlevelIdentifier;
    }
}