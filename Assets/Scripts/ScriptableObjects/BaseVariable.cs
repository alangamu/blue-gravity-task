using System;
using UnityEngine;

namespace BlueGravityTest.Scripts.ScriptableObjects
{
    public class BaseVariable<T> : ScriptableObject
    {
        public T Value => _value;

        public event Action<T> OnValueChanged;

        [SerializeField]
        private T _value;

        public void SetValue(T value)
        {
            _value = value;
            OnValueChanged?.Invoke(_value);
        }
    }
}