using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] Camera _followCamera;
        private Vector3 _movement;
        private Vector3 _movementDirection;
        private PlayerMovement _playerMovement;

        private void Awake()
        {
            _playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            float horizontal = Input.GetAxis(GlobalStringVars.Horizontal_axis);
            float vertical = Input.GetAxis(GlobalStringVars.Vertical_axis);
            _movement = Quaternion.Euler(0, _followCamera.transform.eulerAngles.y,0) * new Vector3(horizontal, 0, vertical);
            _movementDirection = _movement.normalized;

            _playerMovement.JumpCharacter();
        }

        private void FixedUpdate()
        {
            _playerMovement.MoveCharacter(_movementDirection);
           
        }
    }
}
