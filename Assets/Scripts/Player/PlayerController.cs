using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerAnimationController AnimationController;
    public PlayerMotionController MotionController;
    public PlayerInputController InputController;
    public LightReleaseTechnique LightReleaseTechniqueController;

    private float _horizontalInput;
    private float _verticalInput;

    private protected float InputValue;

    private void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        InputController.OnSprintPress += MotionController.SprintPressed;
        InputController.OnSprintRelease += MotionController.SprintReleased;
        InputController.OnJumpPress += MotionController.HandleJump;
        InputController.OnJumpPress += AnimationController.PlayJumpAnim;
        InputController.OnLightReleasePress += LightReleaseTechniqueController.ReleaseLightChi;
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    private void UnsubscribeToEvents()
    {
        InputController.OnSprintPress -= MotionController.SprintPressed;
        InputController.OnSprintRelease -= MotionController.SprintReleased;
        InputController.OnJumpPress -= MotionController.HandleJump;
        InputController.OnJumpPress -= AnimationController.PlayJumpAnim;
        InputController.OnLightReleasePress -= LightReleaseTechniqueController.ReleaseLightChi;
    }

    private void Update()
    {
        Vector2 movement = InputController.GetMovmentInput();

        MotionController.SetInput(movement);
        AnimationController.SetMovementAnim(movement.normalized.magnitude, MotionController.IsSprinting);
    }
}
