using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    private float _speed = 15f;

    public float Speed => _speed;

    public IEnumerator Move(Transform target)
    {
        while(transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            yield return null;
        }
    }

    public abstract void MoveToTarget(Transform point);

    public abstract void MoveToFactory(Transform point);
}
