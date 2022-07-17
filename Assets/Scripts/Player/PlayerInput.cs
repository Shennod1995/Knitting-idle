using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;

    private Vector2 _direction = new Vector2();

    public event UnityAction<Vector2> Running;
    public event UnityAction Stopped;

    private void Update()
    {
        _direction.Set(_joystick.Horizontal, _joystick.Vertical);

        if (_direction != Vector2.zero)
        {
            Running?.Invoke(_direction);
        }
        else
        {
            Stopped?.Invoke();
        }
    }
}