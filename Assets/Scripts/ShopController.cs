using UnityEngine;

namespace Assets.Scripts
{
    public class ShopController : MonoBehaviour
    {
        [SerializeField]
        private Transform _shopUIRoot;

        private void Start()
        {
            _shopUIRoot.gameObject.SetActive(false);
        }
    }
}