using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _playerTransform;
    private Vector3 _offset;

    [SerializeField] private float _mouseSensivity = 3.0f;
    [SerializeField] private Transform _target;
    [SerializeField] private float _distanceFromTarget = 3.0f;
    [SerializeField] private Vector3 _currentRotation;
    [SerializeField] private Vector3 _smoothVelocity = Vector3.zero;
    [SerializeField] private float _smoothTime = 0.2f;
    [SerializeField] private Vector2 _rotationXMinMax = new Vector2(-40, 40);
    private float _rotationY;
    private float _rotationX;
   

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * _mouseSensivity;
        float mouseY = Input.GetAxis("Mouse Y") * _mouseSensivity;

        _rotationY += mouseX;
        _rotationX += mouseY;

        _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);

        Vector3 nextRotation = new Vector3(-_rotationX, _rotationY);

        _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
        transform.localEulerAngles = _currentRotation;

        transform.position = _target.position - transform.forward * _distanceFromTarget;
    }
}
