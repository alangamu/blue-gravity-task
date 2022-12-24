using BlueGravityTest.Scripts.ScriptableObjects;

namespace BlueGravityTest.Scripts.Interfaces
{
    public interface IItemDisplay 
    {
        ClothesItem ClothesItem { get; }
        void Initialize(ClothesItem clothesItem);
    }
}