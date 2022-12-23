using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravity.Scripts.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Lists/Cloth")]
    public class ClothesList : ScriptableObject
    {
        public event Action OnListChanged; 
        public List<ClothesItem> Items = new List<ClothesItem>();

        public void AddClothes(ClothesItem clothesItem)
        {
            Add(clothesItem);
            OnListChanged?.Invoke();
        }

        public void RemoveClothes(ClothesItem clothesItem)
        {
            Remove(clothesItem);
            OnListChanged?.Invoke();
        }

        public List<ClothesItem> GetClothesByType(ClothesType type)
        {
            return Items.FindAll(x => x.ClothesType == type);
        }

        public void SwapClothes(ClothesItem removeClothesItem, ClothesItem addClothesItem)
        {
            Remove(removeClothesItem);
            Add(addClothesItem);
            OnListChanged?.Invoke();
        }

        private void Add(ClothesItem clothesItem)
        {
            Items.Add(clothesItem);
        }

        private void Remove(ClothesItem clothesItem)
        {
            if (Items.Contains(clothesItem))
            {
                Items.Remove(clothesItem);
            }
        }
    }
}