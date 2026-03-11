using UnityEngine;

namespace App.Scripts.Core.Energy
{
    public class EnergyConfig : ScriptableObject
    {
        [SerializeField] private int _maxCount = 5;
        [SerializeField] private float _recoverSpeed = 300f;

        public int MaxCount => _maxCount;
        public float RecoverSpeed => _recoverSpeed;
    }
}