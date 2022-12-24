using BlueGravityTest.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityTest.Scripts
{
    public class EquipClothesController : MonoBehaviour
    {
        [SerializeField]
        private ClothesVariable _activeClothesItemWardrobe;
        [SerializeField]
        private Button _equipButton;
        [SerializeField]
        private ClothesList _wardrobe;
        [SerializeField]
        private ClothesList _inventory;

        private void Start()
        {
            _equipButton.onClick.AddListener(EquipClothes);
        }

        private void EquipClothes()
        {
            ClothesItem activeClothesItemWardrobe = _activeClothesItemWardrobe.Value;
            ClothesItem inventoryItem = _inventory.SwapClothesByType(activeClothesItemWardrobe);
            _wardrobe.RemoveClothes(activeClothesItemWardrobe);
            _wardrobe.AddClothes(inventoryItem);
            _activeClothesItemWardrobe.SetValue(null);
        }
    }
}