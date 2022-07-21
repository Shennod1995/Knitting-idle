using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Animator))]
public class Fabric : Item
{
    private Animator _animator;
    private const string Grabed = "Grabed";
    private bool _isGrabed = false;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHands player))
        {
            if (_isGrabed == false)
            {
                _animator.SetTrigger(Grabed);
                _isGrabed = true;
            }
        }
    }

    public override void Move(Transform target)
    {
        if (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
        }

        transform.rotation = target.rotation;
    }
}