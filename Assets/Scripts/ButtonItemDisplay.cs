using BlueGravityTest.Scripts.Interfaces;
using BlueGravityTest.Scripts.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace BlueGravityTest.Scripts
{
    public class ButtonItemDisplay : MonoBehaviour, IItemDisplay
    {
        public ClothesItem ClothesItem => _clothesItem;
        
        [SerializeField]
        private Image _itemIcon;

        private ClothesItem _clothesItem;

        public void Initialize(ClothesItem clothesItem)
        {
            _clothesItem = clothesItem;
            _itemIcon.sprite = _clothesItem.Icon;
        }
    }
}