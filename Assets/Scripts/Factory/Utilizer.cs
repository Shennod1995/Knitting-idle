using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Utilizer : MonoBehaviour
{
    private BoxCollider _boxCollider;

    public event UnityAction Revised;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Revised?.Invoke();
            Destroy(item.gameObject);
        }
    }
}
