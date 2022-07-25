using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Utilizer : MonoBehaviour
{
    private float _delay = 0.5f;

    public event UnityAction Revised;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Revised?.Invoke();
            StartCoroutine(DestroyWithDelay(item));
        }
    }

    private IEnumerator DestroyWithDelay(Item item)
    {
        yield return new WaitForSeconds(_delay);

        Destroy(item.gameObject);
    }
}
