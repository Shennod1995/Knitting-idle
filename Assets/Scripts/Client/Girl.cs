using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Girl : MonoBehaviour
{
    [SerializeField] private MaterialSetter _materialSetter;
    [SerializeField] private Transform _braContainer;

    private Transform _exit;
    private int _speed = 16;
    private Animator _animator;
    private const float Delay = 1f;
    private const string TurnRight = "TurnRight";
    private const string TurnLeft = "TurnLeft";

    public Transform BraContainer => _braContainer;

    public event UnityAction Payed;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _materialSetter.MaterialChange += Pay;
    }

    private void OnDisable()
    {
        _materialSetter.MaterialChange -= Pay;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Reseption reseption))
        {
            _animator.SetBool(TurnRight, true);
        }
    }

    public void Init(Transform exit) => _exit = exit;

    public void MoveToReseption(Transform target)
    {
        StartCoroutine(Move(target));
    }

    private void Pay()
    {
        Payed?.Invoke();
        _animator.SetBool(TurnLeft, true);
        MoveToExit(_exit);
    }

    private void MoveToExit(Transform target)
    {
        StartCoroutine(Move(target));
    }

    private IEnumerator Move(Transform target)
    {
        yield return new WaitForSeconds(Delay);

        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);
            yield return null;
        }
    }
}