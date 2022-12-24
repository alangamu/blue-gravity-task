using BlueGravityTest.Scripts.ScriptableObjects;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityTest.Scripts
{
    public class BuyClothesController : MonoBehaviour
    {
        [SerializeField]
        private ClothesTypeVariable _activeClothestype;
        [SerializeField]
        private ClothesVariable _activeClothesItemShop;
        [SerializeField]
        private TMP_Text _priceText;
        [SerializeField]
        private Button _buyButton;
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
            _buyButton.onClick.AddListener(BuyClothesItem);
        }

        private void OnEnable()
        {
            _activeClothesItemShop.OnValueChanged += ActiveClothesItemShopOnValueChanged;
            _activeClothestype.OnValueChanged += ActiveClothesTypeChanged;
        }

        private void ActiveClothesTypeChanged(ClothesType obj)
        {
            _activeClothesItemShop.SetValue(null);
        }

        private void OnDisable()
        {
            _activeClothestype.OnValueChanged -= ActiveClothesTypeChanged;
            _activeClothesItemShop.OnValueChanged -= ActiveClothesItemShopOnValueChanged;
        }

        private void ActiveClothesItemShopOnValueChanged(ClothesItem activeClothesItem)
        {
            if (activeClothesItem == null)
            {
                _uiContainerRoot.gameObject.SetActive(false);
            }
            else
            {
                _uiContainerRoot.gameObject.SetActive(true);
                float _buyingPrice = activeClothesItem.BuyingPrice;
                _priceText.text = _buyingPrice.ToString();
                _buyButton.interactable = _cashVariable.Value >= _buyingPrice;
            }
        }

        private void BuyClothesItem()
        {
            ClothesItem activeClothesItemShop = _activeClothesItemShop.Value;
            _cashVariable.SetValue(_cashVariable.Value - activeClothesItemShop.BuyingPrice);
            _shopClothes.RemoveClothes(activeClothesItemShop);
            _wardrobe.AddClothes(activeClothesItemShop);
            _activeClothesItemShop.SetValue(null);
        }
    }
}