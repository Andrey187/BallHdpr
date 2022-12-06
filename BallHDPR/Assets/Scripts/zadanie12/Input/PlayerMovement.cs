using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float _speed = 2.0f;
        [SerializeField, Range(0, 10)] private float _jumpPower = 2.0f;
        [SerializeField] private ForceMode _forceMode;
        [SerializeField] private int _maxJumpCount = 2; //максимальное количество прыжков
        private Rigidbody _playerRigidbody;
        private bool _onGround = true;
        private int _jumpsRemainig = 0; //осталось прыжков

        
        private void Awake()
        {
            _playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 movement)
        {
            _playerRigidbody.AddForce(movement * _speed * Time.deltaTime, _forceMode);
        }

        public void JumpCharacter()
        {
            if((Input.GetKeyDown(KeyCode.Space)) && (_jumpsRemainig > 0))
            {
                _playerRigidbody.AddForce(Vector3.up * _jumpPower, _forceMode);
                _jumpsRemainig -= 1;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Ground"))
            {
                _onGround = true;
                _jumpsRemainig = _maxJumpCount;
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                _onGround = false;
            }
        }
    }
}
