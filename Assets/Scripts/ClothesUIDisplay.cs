using BlueGravity.Scripts.Interfaces;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Scripts.ScriptableObjects
{
    public class ClothesUIDisplay : MonoBehaviour
    {
        [SerializeField]
        private Transform _itemsUIRoot;
        [SerializeField]
        private ClothesList _clothesList;
        [SerializeField]
        private GameObject _itemPrefab;
        [SerializeField]
        private ClothesTypeVariable _activeClothesType;

        private void OnEnable()
        {
            _activeClothesType.OnValueChanged += ActiveClothesTypeOnValueChanged;
            _clothesList.OnListChanged += UpdateDisplay;
        }

        private void OnDisable()
        {
            _activeClothesType.OnValueChanged -= ActiveClothesTypeOnValueChanged;
            _clothesList.OnListChanged -= UpdateDisplay;
        }

        private void ActiveClothesTypeOnValueChanged(ClothesType activeClothesType)
        {
            UpdateDisplay();
        }

        private void Start()
        {
            FillDisplay();
        }

        private void UpdateDisplay()
        {
            ClearUIItems();
            FillDisplay();
        }

        private void ClearUIItems()
        {
            foreach (Transform item in _itemsUIRoot)
            {
                Destroy(item.gameObject);
            }
        }

        private void FillDisplay()
        {
            List<ClothesItem> clothes = _clothesList.GetClothesByType(_activeClothesType.Value);
            foreach (var item in clothes)
            {
                GameObject itemDisplayObject = Instantiate(_itemPrefab, _itemsUIRoot);
                if (itemDisplayObject.TryGetComponent(out IItemDisplay itemDisplay))
                {
                    itemDisplay.Initialize(item);
                }
            }
        }
    }
}