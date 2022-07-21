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
        _player.ItemGiven += OnItem;
    }

    private void OnDisable()
    {
        _player.ItemGiven -= OnItem;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            Grabbed?.Invoke(item);
            item.SetTarget(transform);
            _collider.enabled = false;
        }
    }

    private void OnItem()
    {
        StartCoroutine(TriggerActivationTimer());
    }

    private IEnumerator TriggerActivationTimer()
    {
        yield return new WaitForSeconds(_timeToActivateTrigger);

        _collider.enabled = true;
    }
}