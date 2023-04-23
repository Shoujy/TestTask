using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    private PlayerActions _playerActions = null;

    private Vector2 _moveDirection;
    private bool _isRunning;
    private bool _isInteracting;

    public Vector2 MoveDirection => _moveDirection;
    public bool IsRunning => _isRunning;
    public bool IsInteracting => _isInteracting;

    private void OnEnable()
    {
        if(_playerActions == null)
        {
            _playerActions = new PlayerActions();
        }

        _playerActions.Enable();

        _playerActions.PlayerControls.Movement.performed += OnMovementPerformed;
        _playerActions.PlayerControls.Movement.canceled += OnMovementCanceled;

        _playerActions.PlayerControls.Run.performed += OnRunPerformed;
        _playerActions.PlayerControls.Run.canceled += OnRunCanceled;

        _playerActions.PlayerControls.Interact.performed += OnInteractPerformed;
        _playerActions.PlayerControls.Interact.canceled += OnInteractCanceled;
    }

    private void OnDisable()
    {
        _playerActions.Disable();

        _playerActions.PlayerControls.Movement.performed -= OnMovementPerformed;
        _playerActions.PlayerControls.Movement.canceled -= OnMovementCanceled;

        _playerActions.PlayerControls.Run.performed -= OnRunPerformed;
        _playerActions.PlayerControls.Run.canceled -= OnRunCanceled;

        _playerActions.PlayerControls.Interact.performed -= OnInteractPerformed;
        _playerActions.PlayerControls.Interact.canceled -= OnInteractCanceled;
    }

    private void OnMovementPerformed(InputAction.CallbackContext context)
    {
        _moveDirection = context.ReadValue<Vector2>();
    }
    private void OnRunPerformed(InputAction.CallbackContext context)
    {
        _isRunning = context.ReadValueAsButton();
    }

    private void OnInteractPerformed(InputAction.CallbackContext context)
    {
        _isInteracting = context.ReadValueAsButton();
    }

    private void OnMovementCanceled(InputAction.CallbackContext context)
    {
        _moveDirection = Vector2.zero;
    }

    private void OnRunCanceled(InputAction.CallbackContext context)
    {
        _isRunning = context.ReadValueAsButton();
    }

    private void OnInteractCanceled(InputAction.CallbackContext context)
    {
        _isInteracting = context.ReadValueAsButton();
    }
}
