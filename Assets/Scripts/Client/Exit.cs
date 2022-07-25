using UnityEngine;
using UnityEngine.Events;

public class Exit : MonoBehaviour
{
    public event UnityAction GirlExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Girl girl))
        {
            GirlExit?.Invoke();
            Destroy(girl.gameObject);
        }
    }
}
