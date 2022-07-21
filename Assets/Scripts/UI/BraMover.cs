using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BraMover : MonoBehaviour
{
    private Transform _braContainer;
    private Vector3 _newScale = new Vector3(0.8f, 0.8f, 0.8f);
    private float _speed = 1f;
    private const float _delay = 0.3f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bra bra))
        {
            StartCoroutine(MoveToContainer(bra));
        }
    }

    public void Init(Transform braContainer) => _braContainer = braContainer;

    private IEnumerator MoveToContainer(Bra bra)
    {
        bra.transform.rotation = Quaternion.identity;

        while (bra.transform.localScale != _newScale)
        {
            bra.transform.localScale = Vector3.MoveTowards(bra.transform.localScale, _newScale, _speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(_delay);
        bra.SetTarget(_braContainer);
    }
}
