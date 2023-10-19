using UnityEngine;

public class PlayerMotionController : MonoBehaviour
{
    [Header("Movement")]
    public float BaseSpeed;

    public float SprintSpeed;

    public float GroundDrag;

    public float AirMultiplier;

    [Header("Ground Check")]
    public float PlayerHeight;

    public LayerMask WhatIsGround;
    [SerializeField] private bool _isGrounded;

    public Transform Orientataion;

    private float _horizontalInput;
    private float _verticalInput;

    private Vector3 _movementDirection;

    private Rigidbody _rb;
    [field: SerializeField] public bool IsSprinting { get; private set; }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
    }

    private void Update()
    {
        _isGrounded = Physics.Raycast(transform.position, Vector3.down, PlayerHeight * 0.5f + 0.3f, WhatIsGround);
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
}