using BlueGravityTest.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class CashSound : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _cashVariable;
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip _audioClip;

        private void OnEnable()
        {
            _cashVariable.OnValueChanged += CashVariableChanged;
        }

        private void OnDisable()
        {
            _cashVariable.OnValueChanged += CashVariableChanged;
        }

        private void CashVariableChanged(float cash)
        {
            _audioSource.PlayOneShot(_audioClip);
        }
    }
}