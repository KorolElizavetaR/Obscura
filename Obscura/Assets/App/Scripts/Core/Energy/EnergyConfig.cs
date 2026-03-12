using UnityEngine;

namespace App.Scripts.Core.Energy
{
    public class EnergyConfig : ScriptableObject
    {
        [SerializeField] private int _maxCount = 5;
        [SerializeField] private float _recoverSpeed = 600f;
        [SerializeField] private bool _resetOnStart = false;

        public int MaxCount => _maxCount;
        public float RecoverSpeed => _recoverSpeed;
        public bool ResetOnStart => _resetOnStart;
    }
}