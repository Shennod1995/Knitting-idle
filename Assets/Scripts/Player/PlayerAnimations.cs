using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
    private Player _player;
    private PlayerInput _playerInput;
    private Animator _animator;
    private const string Run = "Run";
    private const string Pull = "Pull";
    private const string Idle = "Idle";
    private const string PullIdle = "PullIdle";

    void Awake()
    {
        _player = GetComponent<Player>();
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        _playerInput.Running += OnRun;
        _playerInput.Stopped += OnIdle;
    }

    private void OnDisable()
    {
        _playerInput.Running -= OnRun;
        _playerInput.Stopped -= OnIdle;
    }

    private void OnRun(Vector2 direction)
    {
        if (_player.HaveItem == false)
        {
            _animator.SetBool(Run, true);
            _animator.SetBool(Idle, false);
            _animator.SetBool(PullIdle, false);
            _animator.SetBool(Pull, false);
        }
        else
        {
            _animator.SetBool(Pull, true);
            _animator.SetBool(PullIdle, false);
            _animator.SetBool(Run, false);
            _animator.SetBool(Idle, false);
        }
    }

    private void OnIdle()
    {
        if (_player.HaveItem == false)
        {
            _animator.SetBool(Run, false);
            _animator.SetBool(Idle, true);
            _animator.SetBool(Pull, false);
            _animator.SetBool(PullIdle, false);
        }
        else
        {
            _animator.SetBool(Pull, false);
            _animator.SetBool(PullIdle, true);
            _animator.SetBool(Run, false);
            _animator.SetBool(Idle, false);
        }
    }
}
