using BlueGravity.Scripts.ScriptableObjects;
using UnityEngine;

namespace BlueGravity.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private float _speed = 3f;
        [SerializeField]
        private BoolVariable _canWalkVariable;

        private Rigidbody2D _rb2d;
        private Animator _animator;
        private Vector2 _moveInput;

        private bool _isFacingRight = true;
        private bool _canWalk;

        private void OnEnable()
        {
            _canWalkVariable.OnValueChanged += CanWalkVariableOnValueChanged;
        }

        private void OnDisable()
        {
            _canWalkVariable.OnValueChanged -= CanWalkVariableOnValueChanged;
        }

        private void Awake()
        {
            TryGetComponent(out _rb2d);
            TryGetComponent(out _animator);
            _canWalk = true;
        }

        private void CanWalkVariableOnValueChanged(bool canWalk)
        {
            _canWalk = canWalk;
        }

        private void Update()
        {
            if (_canWalk)
            {
                float moveX = Input.GetAxisRaw("Horizontal");
                float moveY = Input.GetAxisRaw("Vertical");
                _moveInput = new Vector2(moveX, moveY).normalized;

                _animator.SetFloat("Speed", _moveInput.magnitude);

                if (moveX < 0 && _isFacingRight)
                {
                    transform.Rotate(Vector3.up * 180);
                    _isFacingRight = false;
                }
                if (moveX > 0 && !_isFacingRight)
                {
                    transform.Rotate(Vector3.up * 180);
                    _isFacingRight = true;
                }
            }
        }

        private void FixedUpdate()
        {
            if (_canWalk)
            {
                _rb2d.MovePosition(_rb2d.position + _speed * Time.fixedDeltaTime * _moveInput );
            }
        }
    }
}
