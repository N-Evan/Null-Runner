using UnityEngine;

//Here I am using the PlayerController script as a central brain for the player character controller.
//Each component or module of the player will be handled through here to keep their responsibilities and works separated.
public class PlayerController : MonoBehaviour
{
    public PlayerMotionController MotionController;
    public PlayerInputController InputController;

    private void Start()
    {
        SubscribeToEvents();
    }

    private void SubscribeToEvents()
    {
        InputController.OnSprintPress += MotionController.SprintPressed;
        InputController.OnSprintRelease += MotionController.SprintReleased;
    }

    private void OnDisable()
    {
        UnsubscribeToEvents();
    }

    private void UnsubscribeToEvents()
    {
        InputController.OnSprintPress -= MotionController.SprintPressed;
        InputController.OnSprintRelease -= MotionController.SprintReleased;
    }

    private void Update()
    {
        Vector2 movement = InputController.GetMovementInput();

        MotionController.SetInput(movement);
    }
}