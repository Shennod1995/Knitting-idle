using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class PlayerHands : MonoBehaviour
{
    [SerializeField] private Player _player;

    private BoxCollider _collider;
    private const float _timeToActivateTrigger = 1f;

    public UnityAction<Item> Grabbed;

    private void Start()
    {
        _collider = GetComponent<BoxCollider>();
    }

    private void OnEnable()
    {
        _player.ItemGiven += OnItemGiven;
    }

    private void OnDisable()
    {
        _player.ItemGiven -= OnItemGiven;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Grabbed?.Invoke(item);
            item.MoveToTarget(transform);
            item.transform.rotation = transform.parent.rotation;
            item.transform.parent = transform;
            _collider.enabled = false;
        }
    }

    private void OnItemGiven()
    {
        StartCoroutine(TriggerActivationTimer());
    }

    private IEnumerator TriggerActivationTimer()
    {
        yield return new WaitForSeconds(_timeToActivateTrigger);
        _collider.enabled = true;
    }
}
