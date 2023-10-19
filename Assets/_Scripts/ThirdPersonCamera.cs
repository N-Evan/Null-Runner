using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")]
    public Transform Orientation;

    public Transform Player;
    public Transform PlayerObject;

    public float RotationSpeed;

    private void Update()
    {
        Vector3 viewDirection =
            Player.position - new Vector3(transform.position.x, Player.position.y, transform.position.z);
        Orientation.forward = viewDirection.normalized;

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = Orientation.forward * verticalInput + Orientation.right * horizontalInput;

        if (inputDirection != Vector3.zero)
        {
            PlayerObject.forward = Vector3.Slerp(PlayerObject.forward, inputDirection.normalized, Time.deltaTime * RotationSpeed);
        }
    }
}