using BlueGravityTest.Scripts.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class CharacterOutfitController : MonoBehaviour
    {
        [SerializeField]
        private SpriteRenderer _clothesRendererMain;
        [SerializeField]
        private SpriteRenderer _clothesRendererLeft;
        [SerializeField]
        private SpriteRenderer _clothesRendererRight;
        [SerializeField]
        private ClothesType _clothesType;
        [SerializeField]
        private ClothesList _inventory;

        private void OnEnable()
        {
            _inventory.OnListChanged += ChangeOutfit;
        }

        private void OnDisable()
        {
            _inventory.OnListChanged -= ChangeOutfit;
        }

        private void Start()
        {
            ChangeOutfit();
        }

        private void ChangeOutfit()
        {
            List<ClothesItem> items = _inventory.GetClothesByType(_clothesType);
            if (items.Count > 0)
            {
                ClothesItem item = items[0];

                if (_clothesType._isOnePiece)
                {
                    _clothesRendererMain.sprite = item.ClothesSpriteMain;
                }
                else
                {
                    _clothesRendererLeft.sprite = item.ClothesSpriteLeft;
                    _clothesRendererRight.sprite = item.ClothesSpriteRight;
                }
            }
        }
    }
}