using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IMovabel
{
    private readonly float _speed = 20f;
    private Transform _target;

    public float Speed => _speed;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    private void Update()
    {
        Move(_target);
    }

    public abstract void Move(Transform target);
}
