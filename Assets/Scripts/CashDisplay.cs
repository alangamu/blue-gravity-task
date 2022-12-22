using BlueGravity.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace BlueGravity.Scripts
{
    public class CashDisplay : MonoBehaviour
    {
        [SerializeField]
        private FloatVariable _cashVariable;
        [SerializeField]
        private TMP_Text _cashText;

        private void Start()
        {
            _cashText.text = _cashVariable.Value.ToString();
        }

        private void OnEnable()
        {
            _cashVariable.OnValueChanged += CashVariableOnValueChanged;
        }

        private void OnDisable()
        {
            _cashVariable.OnValueChanged -= CashVariableOnValueChanged;
        }

        private void CashVariableOnValueChanged(float cashValue)
        {
            _cashText.text = cashValue.ToString();
        }
    }
}