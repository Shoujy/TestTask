using UnityEngine;

public class CharacterMonement : MonoBehaviour
{
    [SerializeField] private float _walkSpeed;
    [SerializeField] private float _runSpeed;
    [SerializeField] private float _rotationSpeed;

    private InputSystem _input;
    private Rigidbody _characterRB;

    private Vector3 _movementDirection;
    private bool _isInteracting;
    private bool _isRunning;

    private void Awake()
    {
        _input = GetComponent<InputSystem>();
        _characterRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _movementDirection = Vector3.zero;
        _isInteracting = false;
        _isRunning = false;
    }

    private void Update()
    {
        InputHandle(); 
    }

    private void FixedUpdate()
    {
        if (_isInteracting)
        {
            return;
        }

        RotationHandle();
        MovementHandle();
    }

    private void InputHandle()
    {
        _movementDirection = new Vector3(_input.MoveDirection.x, 0, _input.MoveDirection.y);
        _isInteracting = _input.IsInteracting;
        _isRunning = _input.IsRunning;
    }

    private void RotationHandle()
    {
        if(_movementDirection != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(_movementDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void MovementHandle()
    {
        float speed = _isRunning ? _runSpeed : _walkSpeed;
        _characterRB.velocity = _movementDirection * speed;
    }
}
