using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private PlayerInput _playerInput;
    private Vector3 _direction;
    private Quaternion _rotation;

    public void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.Running += Run;
    }

    private void Run(Vector2 direction)
    {
        _direction.Set(direction.x, 0, direction.y);
        _direction.Normalize();
        transform.Translate(_direction * Time.deltaTime * _speed, Space.World);

        if (_direction != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(_direction, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        _playerInput.Running -= Run;
    }
}