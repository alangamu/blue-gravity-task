using BlueGravityTest.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class ClothesTypeButtonSelector : MonoBehaviour
    {
        [SerializeField]
        private ClothesTypeVariable _activeClothesType;
        [SerializeField]
        private GameObject _selector;
        [SerializeField]
        private ClothesType _clothesType;

        private void Start()
        {
            _selector.SetActive(_activeClothesType.Value == _clothesType);
        }

        private void OnEnable()
        {
            _activeClothesType.OnValueChanged += ActiveClothesTypeChanged;
        }

        private void OnDisable()
        {
            _activeClothesType.OnValueChanged -= ActiveClothesTypeChanged;
        }

        private void ActiveClothesTypeChanged(ClothesType activeClothesType)
        {
            _selector.SetActive(_clothesType == activeClothesType);
        }
    }
}