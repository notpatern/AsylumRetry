using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class BaseMovement : MonoBehaviour
{
    [Header("ref")]
    Rigidbody rb;
    public Transform orientation;
    public PlayerInputs playerControls;
    public LayerMask isGround;
    public float playerHeight;
    public float playerSlideHeight;
    public float currentPlayerHeight;
    public Transform Player;
    public GameObject playerGame;

    [Header("Values")]
    public float moveSpeed;
    public float jumpStrength;
    public float maxMoveSpeed;
    public float maxAirMoveSpeed;
    float currentMaxSpeed;
    public float airMultiplierValue;
    public float groundDrag;
    public float airDrag;
    float currentDrag;
    bool grounded;


    Vector3 moveDirection;
    private float airMultiplier;
    private InputAction move;

    private void Awake()
    {
        playerControls = new PlayerInputs();
    }

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();
    }
    private void OnDisable()
    {
        move.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.drag = groundDrag;
        currentPlayerHeight = 1;
        Player.localScale = new Vector3(Player.localScale.x, playerHeight, Player.localScale.z);
        grounded = false;
    }

    void Update()
    {
        CheckGrounded();
        StateMachine();
    }

    private void FixedUpdate()
    {
        MoveInputs();
    }

    private void StateMachine()
    {
        if (grounded)
        {
            rb.drag = groundDrag;
            airMultiplier = 1f;
            currentMaxSpeed = maxMoveSpeed;
            rb.useGravity = true;
        }
        else
        {
            rb.drag = airDrag;
            airMultiplier = airMultiplierValue;
            currentMaxSpeed = maxAirMoveSpeed;
            rb.useGravity = true;
        }
    }

    private void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, currentPlayerHeight + 0.2f, isGround);
    }

    private void MoveInputs()
    {
        float x = move.ReadValue<Vector2>().x;
        float y = move.ReadValue<Vector2>().y;

        Vector2 mag = FindVelRelativeToLook();
        float xMag = mag.x, yMag = mag.y;

        if (x > 0 && xMag > maxMoveSpeed) x = 0;
        if (x < 0 && xMag < -maxMoveSpeed) x = 0;
        if (y > 0 && yMag > maxMoveSpeed) y = 0;
        if (y < 0 && yMag < -maxMoveSpeed) y = 0;

        moveDirection = orientation.forward * y + orientation.right * x;
        rb.AddForce(moveDirection.normalized * 10f * moveSpeed * airMultiplier, ForceMode.Acceleration);
    }

    public Vector2 FindVelRelativeToLook()
    {
        float lookAngle = orientation.transform.eulerAngles.y;
        float moveAngle = Mathf.Atan2(rb.velocity.x, rb.velocity.z) * Mathf.Rad2Deg;

        float u = Mathf.DeltaAngle(lookAngle, moveAngle);
        float v = 90 - u;

        float magnitue = rb.velocity.magnitude;
        float yMag = magnitue * Mathf.Cos(u * Mathf.Deg2Rad);
        float xMag = magnitue * Mathf.Cos(v * Mathf.Deg2Rad);

        return new Vector2(xMag, yMag);
    }
}
