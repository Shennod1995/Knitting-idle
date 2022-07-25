using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Girl : MonoBehaviour
{
    [SerializeField] private MaterialSetter _materialSetter;
    [SerializeField] private Transform _braContainer;
    [SerializeField] private Waypoint_Indicator _indicator;

    private Transform _exit;
    private float _moveSpeed = 16f;
    private float _iconSizeSpeed = 2f;
    private Animator _animator;
    private const float Delay = 1f;
    private const float TargetSize = 2f;
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
            _indicator.enabled = true;
            StartCoroutine(SpriteSizeMover());
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

    private IEnumerator SpriteSizeMover()
    {
        while (_indicator.onScreenSpriteSize != TargetSize)
        {
            _indicator.onScreenSpriteSize = Mathf.MoveTowards(_indicator.onScreenSpriteSize, TargetSize, _iconSizeSpeed * Time.deltaTime);
            _indicator.offScreenSpriteSize = Mathf.MoveTowards(_indicator.offScreenSpriteSize, TargetSize, _iconSizeSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator Move(Transform target)
    {
        yield return new WaitForSeconds(Delay);

        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, _moveSpeed * Time.deltaTime);
            yield return null;
        }
    }
}