using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SmoothMoveToTarget : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            item.SetTarget(_target);
        }
    }
}