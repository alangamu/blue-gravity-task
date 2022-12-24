using UnityEngine;

namespace BlueGravityTest.Scripts
{
    public class PlayerMovementSound : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _audioSource;
        [SerializeField]
        private AudioClip[] _clips;

        public void Step()
        {
            _audioSource.PlayOneShot(_clips[Random.Range(0, _clips.Length)]);
        }
    }
}