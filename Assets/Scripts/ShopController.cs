using BlueGravity.Scripts.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField]
        private Transform _shopUIRoot;

        [SerializeField]
        private Transform _wardrobeRoot;

        [SerializeField]
        private Transform _shopItemsRoot;

        public void UpdateWardrobeDisplay(ClothesType clothesType)
        {

        }

        private void Start()
        {
            _shopUIRoot.gameObject.SetActive(false);
        }
    }
}