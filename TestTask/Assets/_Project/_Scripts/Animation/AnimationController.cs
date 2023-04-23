using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private InputSystem _input;

    private int _currentState;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _input = GetComponent<InputSystem>();
    }

    private void Update()
    {
        if (_input.IsInteracting)
        {
            _animator.CrossFade(Idle, 0.2f, 0);
            _currentState = Idle;
            return;
        }

        var state = GetState();

        if(state == _currentState)
        {
            return;
        }

        _animator.CrossFade(state, 0.2f, 0);
        _currentState = state;
    }

    private int GetState()
    {
        if (_input.IsRunning && _input.MoveDirection != Vector2.zero)
        {
            return Run;
        }

        return _input.MoveDirection == Vector2.zero ? Idle : Walk;
    }

    #region Cached Properties

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Walk = Animator.StringToHash("Walk");
    private static readonly int Run = Animator.StringToHash("Run");

    #endregion
}
