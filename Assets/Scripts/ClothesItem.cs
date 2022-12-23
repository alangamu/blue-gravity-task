using BlueGravity.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlueGravity.Scripts
{
    [CreateAssetMenu(menuName = "Clothes/Item")]
    public class ClothesItem : ScriptableObject
    {
        public Sprite Icon;
        public Sprite ClothesSpriteMain;
        public Sprite ClothesSpriteLeft;
        public Sprite ClothesSpriteRight;
        public ClothesType ClothesType;
        public float SellingPrice;
        public float BuyingPrice;
    }
}