using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class PopupEffect : MonoBehaviour
    {
        [SerializeField]
        private GameObject _effectObject;

        public void Close()
        {
            LeanTween.scale(_effectObject, Vector3.zero, .5f).setOnComplete(()=> _effectObject.SetActive(false)).setEase(LeanTweenType.easeInBounce);
        }

        public void Open()
        {
            _effectObject.SetActive(true);
            _effectObject.transform.localScale = Vector3.zero;
            LeanTween.scale(_effectObject, Vector3.one, .5f).setEase(LeanTweenType.easeInBounce);
        }

    }
}