using BlueGravityTest.Scripts.Interfaces;
using BlueGravityTest.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class ClothesItemButtonSelector : MonoBehaviour
    {
        [SerializeField]
        private ClothesVariable _activeClothesItem;
        [SerializeField]
        private GameObject _selector;

        private IItemDisplay _clothesItemDisplay;

        public void SetActiveClothesItem()
        {
            _activeClothesItem.SetValue(_clothesItemDisplay.ClothesItem);
        }

        private void Start()
        {
            _selector.SetActive(false);
        }

        private void OnEnable()
        {
            _activeClothesItem.OnValueChanged += ActiveClothesTypeOnValueChanged;
            TryGetComponent(out _clothesItemDisplay);
        }

        private void OnDisable()
        {
            _activeClothesItem.OnValueChanged -= ActiveClothesTypeOnValueChanged;
        }

        private void ActiveClothesTypeOnValueChanged(ClothesItem activeClothesItem)
        {
            _selector.SetActive(_clothesItemDisplay.ClothesItem == activeClothesItem);
        }
    }
}