using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Money : MonoBehaviour
{
    [SerializeField] private int _value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Player player))
        {
            player.TakeMoney(_value);
            Destroy(gameObject);
        }
    }
}
