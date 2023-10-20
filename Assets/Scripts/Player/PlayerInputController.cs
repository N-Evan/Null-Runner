using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    public float GetHorizontalInput()
    {
        return Input.GetAxis("Horizontal");
    }

    public float GetVerticalInput()
    {
        return Input.GetAxis("Vertical");
    }

    public bool GetJumpInput()
    {
        return Input.GetKey(KeyCode.Space);
    }



    private PlayerControls _playerControls;

    public delegate void OnMoveEvent(Vector2 direction);
    public OnMoveEvent OnMovement;

    public delegate void OnActionEvent();

    #region Ground Movement

    public OnActionEvent OnJumpPress;
    public OnActionEvent OnJumpRelease;
    public OnActionEvent OnTapInteract;
    public OnActionEvent OnSprintPress;
    public OnActionEvent OnSprintRelease;
    public OnActionEvent OnOpenInventory;
    public OnActionEvent OnPausePress;
    public OnActionEvent OnCrouchPress;

    #endregion

    #region UIMap

    public OnActionEvent OnCancelAction;
    public OnActionEvent OnUnpauseAction;
    public OnActionEvent OnCutsceneSkipAction;

    #endregion

    private void Awake()
    {
        _playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
        _playerControls.Enable();
    }

    private void OnDisable()
    {
        _playerControls.Disable();
    }


    #region Ground Movement

    public void Move(InputAction.CallbackContext context)
    {
        OnMovement?.Invoke(context.ReadValue<Vector2>());
    }

    public Vector2 GetMovmentInput()
    {
        return _playerControls.GroundMovement.GroundMovement.ReadValue<Vector2>();
    }

    public Vector2 GetMouseDelta()
    {
        return _playerControls.GroundMovement.MouseLook.ReadValue<Vector2>();
    }

    public bool SprintButton()
    {
        if (_playerControls.GroundMovement.SprintButton.phase == InputActionPhase.Started)
        {
            OnSprintPress?.Invoke();
        }
        else if (_playerControls.GroundMovement.SprintButton.phase == InputActionPhase.Canceled)
        {
            OnSprintRelease?.Invoke();
        }
        return _playerControls.GroundMovement.SprintButton.ReadValue<bool>();
    }

    public void JumpPress(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnJumpPress?.Invoke();
    }

    public void SprintPress(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnSprintPress?.Invoke();
    }

    public void SprintRelease(InputAction.CallbackContext context)
    {
        if (!context.canceled) return;
        OnSprintRelease?.Invoke();
    }

    public void JumpButton(InputAction.CallbackContext context)
    {
        if (context.canceled)
            OnJumpRelease?.Invoke();
        else if (context.started)
            OnJumpPress?.Invoke();
    }

    public void TapInteraction(InputAction.CallbackContext context)
    {
        //Debug.Log("Tap Hit #1" + context.phase);
        if (!context.performed) return;
        //Debug.Log("Tap Hit #2" + context.phase);
        OnTapInteract?.Invoke();
    }

    public void OpenInventoryAction(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnOpenInventory?.Invoke();
    }

    public void PausePress(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnPausePress?.Invoke();
    }

    #endregion

    #region UI Map

    public void CancelAction(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnCancelAction?.Invoke();
    }

    public void UnpauseAction(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnUnpauseAction?.Invoke();
    }

    public void SkipCutscene(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        OnCutsceneSkipAction?.Invoke();
    }

    #endregion
}
