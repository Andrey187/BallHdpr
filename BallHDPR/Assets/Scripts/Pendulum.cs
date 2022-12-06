using UnityEngine;

public class Pendulum : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _leftAngle;
    [SerializeField] private float _rightAngle;
    private bool _movingClockwise;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        _movingClockwise = true;
    }
    private void Update()
    {
        Move();
    }

    public void ChangeMoveDir()
    {
        if (transform.rotation.z > _rightAngle)
        {
            _movingClockwise = false;
        }
        if (transform.rotation.z < _leftAngle)
        {
            _movingClockwise = true;
        }
    }

    public void Move()
    {
        ChangeMoveDir();

        if (_movingClockwise)
        {
            rb.angularVelocity = new Vector3(0, 0, Random.Range(0, _moveSpeed));
        }

        if (!_movingClockwise)
        {
            rb.angularVelocity = new Vector3(0, 0, Random.Range(0, -1 * _moveSpeed));
        }
    }
}
