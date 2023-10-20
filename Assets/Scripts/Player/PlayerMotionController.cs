using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    [Header("Movement")]
    public float BaseSpeed;
    public float SprintSpeed;

    public float GroundDrag;

    public float JumpForce;
    public float JumpCooldown;
    public float AirMultiplier;
    bool _isReadyToJump;

    

    [Header("Ground Check")]
    public float PlayerHeight;
    public LayerMask WhatIsGround;
    [SerializeField] private bool _isGrounded;

    public Transform Orientataion;

    private float _horizontalInput;
    private float _verticalInput;

    Vector3 _movementDirection;

    Rigidbody _rb;
    [field: SerializeField] public bool IsSprinting { get; private set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;

        _isReadyToJump = true;
    }

    private void Update()
    {
        // ground check
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.3f, WhatIsGround);

        //SpeedControl();

        // handle drag
        if (_isGrounded)
            _rb.drag = GroundDrag;
        else
            _rb.drag = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    public void SprintPressed()
    {
        IsSprinting = true;
    }

    public void SprintReleased()
    {
        IsSprinting = false;
    }

    public void SetInput(Vector2 inputValues)
    {
        _horizontalInput = inputValues.x;
        _verticalInput = inputValues.y;
    }

    public void HandleJump()
    {
        if (_isReadyToJump && _isGrounded)
        {
            _isReadyToJump = false;

            Jump();

            Invoke(nameof(ResetJump), JumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // calculate movement direction
        _movementDirection = Orientataion.forward * _verticalInput + Orientataion.right * _horizontalInput;
        var speedToMultiply = GetSpeedToMultiply();
        // on ground
        if (_isGrounded)
            _rb.AddForce(_movementDirection.normalized * speedToMultiply * 10f, ForceMode.Force);

        // in air
        else if (!_isGrounded)
            _rb.AddForce(_movementDirection.normalized * BaseSpeed * 10f * AirMultiplier, ForceMode.Force);
    }

    private float GetSpeedToMultiply()
    {
        return IsSprinting ? SprintSpeed : BaseSpeed;
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        // limit velocity if needed
        if (flatVel.magnitude > BaseSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * GetSpeedToMultiply();
            _rb.velocity = new Vector3(limitedVel.x, _rb.velocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        // reset y velocity
        _rb.velocity = new Vector3(_rb.velocity.x, 0f, _rb.velocity.z);

        //_rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
    }
    private void ResetJump()
    {
        _isReadyToJump = true;
    }
}
