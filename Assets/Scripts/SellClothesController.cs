using BlueGravityTest.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityTest.Scripts
{
    public class SellClothesController : MonoBehaviour
    {
        [SerializeField]
        private ClothesTypeVariable _activeClothesType;
        [SerializeField]
        private ClothesVariable _activeClothesItemWardrobe;
        [SerializeField]
        private TMP_Text _priceText;
        [SerializeField]
        private Button _sellButton;
        [SerializeField]
        private Transform _uiContainerRoot;
        [SerializeField]
        private FloatVariable _cashVariable;
        [SerializeField]
        private ClothesList _wardrobe;
        [SerializeField]
        private ClothesList _shopClothes;

        private void Start()
        {
            _uiContainerRoot.gameObject.SetActive(false);
            _sellButton.onClick.AddListener(SellClothesItem);
        }

        private void OnEnable()
        {
            _activeClothesItemWardrobe.OnValueChanged += ActiveClothesItemWardrobeChanged;
            _activeClothesType.OnValueChanged += ActiveClothesTypeChanged;
        }

        private void OnDisable()
        {
            _activeClothesItemWardrobe.OnValueChanged -= ActiveClothesItemWardrobeChanged;
            _activeClothesType.OnValueChanged -= ActiveClothesTypeChanged;
        }

        private void ActiveClothesTypeChanged(ClothesType obj)
        {
            _activeClothesItemWardrobe.SetValue(null);
        }

        private void ActiveClothesItemWardrobeChanged(ClothesItem activeWardrobeItem)
        {
            if (activeWardrobeItem == null)
            {
                _uiContainerRoot.gameObject.SetActive(false);
            }
            else
            {
                _uiContainerRoot.gameObject.SetActive(true);
                float _sellingPrice = activeWardrobeItem.SellingPrice;
                _priceText.text = _sellingPrice.ToString();
            }
        }

        private void SellClothesItem()
        {
            ClothesItem activeClothesItemWardrobe = _activeClothesItemWardrobe.Value;
            _cashVariable.SetValue(_cashVariable.Value + activeClothesItemWardrobe.SellingPrice);
            _shopClothes.AddClothes(activeClothesItemWardrobe);
            _wardrobe.RemoveClothes(activeClothesItemWardrobe);
            _activeClothesItemWardrobe.SetValue(null);
        }
    }
}