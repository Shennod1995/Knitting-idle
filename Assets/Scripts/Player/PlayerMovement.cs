using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private PlayerInput _playerInput;
    private Vector3 _direction;
    private Transform _transform;
    private Quaternion _rotation;

    public void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _transform = GetComponent<Transform>();
        _playerInput.Running += Run;
    }


    private void Run(Vector2 direction)
    {
        _direction.Set(direction.x, 0, direction.y);
        _direction.Normalize();
        _transform.Translate(_direction * Time.deltaTime * _speed, Space.World);

        if (_direction != Vector3.zero)
        {
            _rotation = Quaternion.LookRotation(_direction, Vector3.up);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, _rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void Pulled(Vector2 direction)
    {

    }

    private void OnDisable()
    {
        _playerInput.Running -= Run;
    }
}