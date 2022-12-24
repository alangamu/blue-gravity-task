using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class InteractableUI : MonoBehaviour
    {
        [SerializeField]
        private Transform _uiRoot;
        [SerializeField]
        private Outline _outline;

        private bool _isOn = false;

        private void Start()
        {
            _uiRoot.gameObject.SetActive(false);
            _outline.enabled = false;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _isOn = true;
            _outline.enabled = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _isOn = false;
            _uiRoot.gameObject.SetActive(false);
            _outline.enabled = false;
        }

        private void OnMouseUpAsButton()
        {
            if (_isOn)
            {
                _uiRoot.gameObject.SetActive(true);
            }
        }
    }
}