using System;
using UnityEngine;

namespace BlueGravity.Scripts.Interfaces
{
    public interface IItemDisplay 
    {
        ClothesItem ClothesItem { get; }
        void Initialize(ClothesItem clothesItem);
    }
}